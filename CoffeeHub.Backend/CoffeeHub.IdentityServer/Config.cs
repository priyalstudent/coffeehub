using Duende.IdentityServer.Models;

namespace CoffeeHub.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("coffeehub.api", "CoffeeHub API")
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                // m2m client credentials flow client
                //new Client
                //{
                //    ClientId = "m2m.client",
                //    ClientName = "Client Credentials Client",

                //    AllowedGrantTypes = GrantTypes.ClientCredentials,
                //    ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

                //    AllowedScopes = { "coffeehub.api" }
                //},

                // interactive client using code flow + pkce
                //new Client
                //{
                //    ClientId = "interactive",
                //    ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },

                //    AllowedGrantTypes = GrantTypes.Code,

                //    RedirectUris = { "https://localhost:44300/signin-oidc" },
                //    FrontChannelLogoutUri = "https://localhost:44300/signout-oidc",
                //    PostLogoutRedirectUris = { "https://localhost:44300/signout-callback-oidc" },

                //    AllowOfflineAccess = true,
                //    AllowedScopes = { "openid", "profile", "coffeehub.api" }
                //},

                new Client
                {
                        ClientId = "postman-client",
                        ClientName = "Postman",

                        AllowedGrantTypes = GrantTypes.ClientCredentials,
                        ClientSecrets =
                        {
                            new Secret("secret".Sha256())
                        },

                        AllowedScopes = { "coffeehub.api" }
                },

                new Client
                {
                        ClientId = "coffeehub-react",
                        ClientName = "CoffeeHub React App",

                        AllowedGrantTypes = GrantTypes.Code,
                        RequirePkce = true,
                        RequireClientSecret = false,
                    
                        PostLogoutRedirectUris = { "http://localhost:5173/", "http://localhost:5173/login"},
                        AllowedCorsOrigins = {"http://localhost:5173" },
                        RedirectUris = { "http://localhost:5173/callback" },

                        AllowedScopes =
                        {
                            "openid",
                            "profile",
                            "coffeehub.api"
                        },

                        AllowAccessTokensViaBrowser = true
                }

            };
    }
}
