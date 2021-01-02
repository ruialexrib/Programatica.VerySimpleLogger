using Programatica.VerySimpleLogger.Data.Models;
using System.Threading.Tasks;

namespace Programatica.VerySimpleLogger.Client.Test
{
    class Program
    {
        static async Task Main(string[] args)
        {
            VerySimpleLoggerClient.ServerUrl = "http://raspberrypi4:8099/api/logs/";
            await VerySimpleLoggerClient.LogAsync("Main", LogLevelEnum.Debug, "Just another info message");
        }
    }
}
