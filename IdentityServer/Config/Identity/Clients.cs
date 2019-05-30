using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Config.Identity
{
    public static class Clients
    {
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "xamarin",
                    ClientName = "Xamarin client",
                    AllowedGrantTypes = {
                        GrantType.ResourceOwnerPassword,
                        GrantType.ClientCredentials,
                        "refresh_token"
                    },
                    RequireConsent = false,
                    ClientSecrets =
                    {
                        new Secret("b2505339-97c9-41cc-b0c2-80406976767a".Sha256())
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        "Profile.API",
                        "Garden.API"
                    },
                    AllowOfflineAccess = true,
                    AlwaysSendClientClaims = true,
                    AlwaysIncludeUserClaimsInIdToken = true,
                    SlidingRefreshTokenLifetime = 1296000,
                    AbsoluteRefreshTokenLifetime = 2592000,
                    UpdateAccessTokenClaimsOnRefresh = true,
                    AccessTokenLifetime = 500000
                }
            };
        }
    }
}
