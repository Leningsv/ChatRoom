using ChatRoom.Models.Users;
using ChatRoom.Utils;
using ChatRoom.Utils.Enums;
using IdentityModel.Client;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ChatRoom.Client
{
    class Program
    {
        private const string SECRET_CHAT_ROOM_CLIENT = "SecretChatRoomClient";
        static void Main(string[] args) => MainAsync().GetAwaiter().GetResult();
        private static async Task MainAsync()
        {
            TokenResponse tokenResponse = GetToken("leningsv", "nada1234").Result;
            Console.WriteLine(tokenResponse);
        }

        private static async Task<TokenResponse> GetToken(string username, string password)
        {
            DiscoveryResponse disco = await DiscoveryClient.GetAsync(GeneralSettings.IDENTITY_SERVER_URL);
            if (disco.IsError)
            {
                Console.WriteLine(disco.Error);
                throw new Exception(disco.Error);
            }
            TokenClient tokenClient = new TokenClient(disco.TokenEndpoint, IdentityServerClientEnum.ChatRoomClient.ToString(),
                SECRET_CHAT_ROOM_CLIENT);
            TokenResponse tokenResponse = await tokenClient.RequestResourceOwnerPasswordAsync(
                username,
                password,
                IdentityServerResourceEnum.ChatRoomResource.ToString()
            );

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                throw new Exception(tokenResponse.Error);
            }
            return tokenResponse;
        }
    }
}
