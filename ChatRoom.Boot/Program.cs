using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatRoom.Boot
{
    class Program
    {
        private const string URL_STOCK = "https://stooq.com/q/l/?s=aapl.us&f=sd2t2ohlcv&h&e=csv";

        static void Main(string[] args) => MainAsync().GetAwaiter().GetResult();

        private static async Task MainAsync()
        {
            string correntStock = GetCurrentStockCSV();
            Dictionary<string, string> a = DecodeCurrentStockCSV(correntStock);
        }

        private static string GetCurrentStockCSV()
        {
            RestClient client = new RestClient(URL_STOCK);
            // client.Authenticator = new HttpBasicAuthenticator(username, password);
            RestRequest request = new RestRequest("", Method.GET);

            // execute the request
            IRestResponse response = client.Execute(request);
            string content = response.Content;
            return content;
        }

        private static Dictionary<string, string> DecodeCurrentStockCSV(string content)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            for (int i = 0; i < content.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).Length; i++)
            {
                for (int j = 0; j < content.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)[i].Split(",").Length; j++)
                {
                    if (i > 0)
                    {
                        result.Add(
                            content.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)[0].Split(",")[j],
                            content.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)[i].Split(",")[j]
                            );
                    }
                }
                if (i > 1)
                {
                    break;
                }
            }
            return result;
        }
    }
}
