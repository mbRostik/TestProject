using Duende.IdentityServer.Models;

namespace IdentityServerAPI
{
    public class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
           new IdentityResource[]
           {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource
                {
                    Name="role",
                    UserClaims=new List<string>{"role"}
                }
           };


        public static IEnumerable<ApiScope> ApiScopes =>
           new ApiScope[]
           {
               new ApiScope("postAPI.read"),
               new ApiScope("postAPI.write"),

               new ApiScope("newAPI.read"),
               new ApiScope("newAPI.write")
           };


        public static IEnumerable<ApiResource> ApiResources => new[] {
             new ApiResource("postAPI")
             {
                 Scopes=new List<string>{ "postAPI.read", "postAPI.write" },
                 ApiSecrets=new List<Secret>{new Secret("ScopeSecret".Sha256())},
                 UserClaims=new List<string>{"role"}
             },
             new ApiResource("newAPI")
             {
                 Scopes=new List<string>{ "newAPI.read", "newAPI.write" },
                 ApiSecrets=new List<Secret>{new Secret("ScopeSecret".Sha256())},
                 UserClaims=new List<string>{"role"}
             }
        };


        public static IEnumerable<Client> Clients =>
           new Client[]
           {
               new Client
                   {
                        ClientId = "new.Client",
                        ClientName="Client Credential Client",
                        AllowedGrantTypes = GrantTypes.ClientCredentials,

                        ClientSecrets ={ new Secret("WhoNkowsitemClientSecret".Sha256()) },
                        AllowedScopes = { "newAPI.read", "newAPI.write" }
                   },
                   new Client
                   {    
                       ClientId = "interactive",
                       ClientSecrets = {new Secret("OnlyUserKnowsThisSecret".Sha256())},
                       AllowedGrantTypes = GrantTypes.Code,
                       RedirectUris = { "https://localhost:7225/signin-oidc" },
                       FrontChannelLogoutUri="https://localhost:7225/signout-oidc",
                       PostLogoutRedirectUris={ "https://localhost:7225/signout-callback-oidc" },
                       AllowOfflineAccess = true,
                       AllowedScopes = {"openid", "profile", "postAPI.read"},
                       RequireConsent = true,
                       RequirePkce=true,
                       AllowPlainTextPkce=true
                   }
           };
    }
}
