using Application.SQLContracts.NewAPI;
using Application.UseCases.NewAPI.Queries;
using Infrastructure.SQLServer.NewAPI;
using Infrastructure.SQLServer.NewAPI.NewAPIRepositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.EntityFrameworkCore;
using NewAPI.Models;
using NewAPI.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<IdentityServerOptions>(builder.Configuration.GetSection("IdentityServerSettings"));

builder.Services.AddScoped<INewRepository, NewRepository>();
builder.Services.AddScoped<INewUOW, NewUOW>();
builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddDbContext<NewDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MSSQLConnection"));
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = "https://localhost:7233";

        options.Audience = "newAPI";

    });
builder.Services.AddMediatR(options =>
{
    options.RegisterServicesFromAssemblies(typeof(GetAllNewQuery).Assembly);

});



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
