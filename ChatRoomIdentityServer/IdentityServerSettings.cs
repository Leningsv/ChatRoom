using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatRoomIdentityServer
{
    public class IdentityServerSettings
    {
        // Implicit folw identity resources
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>()
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }
        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>()
            {
                new TestUser()
                {
                    Username = "Lenin Samaniego",
                    Password = "nada1234"
                },
                new TestUser()
                {
                    Username = "Guillermo",
                    Password = "nada1234"
                }
            };
        }
        public static IEnumerable<ApiResource> GetAllApiResources()
        {
            return new List<ApiResource>()
            {
                new ApiResource("ChatRoomResource", "Resource of principal aplication Chat room"),
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            // Client-Credential base grant type
            return new List<Client>()
            {
                new Client()
                {
                    ClientId = "ChatRoomClient",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("SecretChatRoomClient".Sha256())
                    },
                    AllowedScopes = { "ChatRoomResource" }
                }
            };
        }
    }
}
