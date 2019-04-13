using ChatRoom.Utils.Enums;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;

namespace ChatRoomIdentityServer
{
    public class IdentityServerSettings
    {
        private const string SECRET_CHAT_ROOM_CLIENT = "SecretChatRoomClient";
        private const int DEFAUL_ACCESS_TOKEN_LIFE_TIME = 172800;
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
                    SubjectId = "0",
                    Username = "leningsv",
                    Password = "nada1234"
                },
                new TestUser()
                {
                    SubjectId = "1",
                    Username = "leninsvg",
                    Password = "nada1234"
                }
            };
        }
        public static IEnumerable<ApiResource> GetAllApiResources()
        {
            return new List<ApiResource>()
            {
                new ApiResource(IdentityServerResourceEnum.ChatRoomResource.ToString(), 
                    "Resource of principal aplication Chat room"),
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            // Client-Credential base grant type
            return new List<Client>()
            {
                new Client()
                {
                    AccessTokenLifetime = DEFAUL_ACCESS_TOKEN_LIFE_TIME,
                    ClientId = IdentityServerClientEnum.ChatRoomClient.ToString(),
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets =
                    {
                        new Secret(SECRET_CHAT_ROOM_CLIENT.Sha256())
                    },
                    AllowedScopes = { IdentityServerResourceEnum.ChatRoomResource.ToString() }
                }
            };
        }
    }
}
