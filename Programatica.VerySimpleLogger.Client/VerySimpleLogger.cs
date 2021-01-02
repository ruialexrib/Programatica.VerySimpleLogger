using Programatica.VerySimpleLogger.Data.Models;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace Programatica.VerySimpleLogger.Client
{
    public static class VerySimpleLogger
    {
        public static string ServerUrl { get; set; }

        public static async Task LogAsync(string caller, LogLevelEnum level, string message)
        {
            var log = new Log
            {
                Caller = caller,
                Level = level,
                Message = message,
                CreatedDate = DateTime.Now
            };

            var client = new RestClient();
            var request = new RestRequest(ServerUrl, Method.POST).AddJsonBody(log);
            await client.ExecuteAsync(request);
        }
    }
}
