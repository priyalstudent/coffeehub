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
                    ClientId = "coffeehub.client",
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                    AllowedScopes =
                    {
                        "openid",
                        "profile",
                        "coffeehub.api"
                    }
                },

                new Client
                {
                        ClientId = "coffeehub-react",
                        ClientName = "CoffeeHub React App",

                        AllowedGrantTypes = GrantTypes.Code,
                        RequirePkce = true,
                        RequireClientSecret = false,

                        RedirectUris = { "https://coffeehub-frontend-web-e9b4exbufwfxh8bn.francecentral-01.azurewebsites.net/callback" },
                        AllowedCorsOrigins = {"https://coffeehub-frontend-web-e9b4exbufwfxh8bn.francecentral-01.azurewebsites.net"},
                        PostLogoutRedirectUris = { "https://coffeehub-frontend-web-e9b4exbufwfxh8bn.francecentral-01.azurewebsites.net/"},

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
