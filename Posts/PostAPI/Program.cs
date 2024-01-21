using Application.SQLContracts.PostAPI;
using Application.UseCases.PostAPI.Handlers.Consumers;
using Application.UseCases.PostAPI.Queries;
using Infrastructure.SQLServer.PostAPI;
using Infrastructure.SQLServer.PostAPI.PostAPIRepositories;
using MassTransit;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.EntityFrameworkCore;
using PostAPI.Models;
using PostAPI.Policies;
using PostAPI.Services;
using PostAPI.Services.grpcServices;
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

builder.Services.Configure<IdentityServerOptions>(builder.Configuration.GetSection("IdentityServerSettings"));
builder.Services.AddSingleton<ClientPolicy>(new ClientPolicy());

builder.Services.AddScoped<IPost_UserRepository, Post_UserRepository>();
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<IUserWithPostRepository, UserWithPostRepository>();
builder.Services.AddScoped<IPostUOW, PostUOW>();
builder.Services.AddScoped<ITokenService,  TokenService>();


builder.Services.AddDbContext<PostDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MSSQLConnection"));
});


builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
})
.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
.AddOpenIdConnect(
    OpenIdConnectDefaults.AuthenticationScheme,
    options =>
    {
        options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.SignOutScheme = OpenIdConnectDefaults.AuthenticationScheme;
        options.Authority = builder.Configuration["InteractiveServiceSettings:AuthorityUrl"];
        options.ClientId = builder.Configuration["InteractiveServiceSettings:ClientId"];
        options.ClientSecret = builder.Configuration["InteractiveServiceSettings:ClientSecret"];

        options.ResponseType = "code";
        options.SaveTokens = true;
        options.GetClaimsFromUserInfoEndpoint = true;

    }
);


builder.Services.AddMediatR(options =>
{
    options.RegisterServicesFromAssemblies(typeof(GetAllUser_PostQuery).Assembly);

});

builder.Services.AddMassTransit(x =>
{
    x.AddConsumers(typeof(UserCreatedConsumer).Assembly);
    x.UsingRabbitMq((cxt, cfg) =>
    {
        cfg.Host("localhost", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });
        cfg.ConfigureEndpoints(cxt);
    });
});

builder.Services.AddGrpc();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapGrpcService<grpcPostService>();
    endpoints.MapGrpcService<grpcPost_UserService>();

    endpoints.MapGet("/protos/post.proto", async context =>
    {
        await context.Response.WriteAsync(File.ReadAllText("protos/post.proto"));
    });
    endpoints.MapGet("/protos/post_user.proto", async context =>
    {
        await context.Response.WriteAsync(File.ReadAllText("protos/post_user.proto"));
    });
});

// Configure the HTTP request pipeline.


app.MapControllers();

app.Run();
