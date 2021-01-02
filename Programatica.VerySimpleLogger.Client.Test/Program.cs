using Programatica.VerySimpleLogger.Data.Models;
using System.Threading.Tasks;

namespace Programatica.VerySimpleLogger.Client.Test
{
    class Program
    {
        static async Task Main(string[] args)
        {
            VerySimpleLogger.ServerUrl = "http://raspberrypi4:8099/api/logs/";
            await VerySimpleLogger.LogAsync("Main", LogLevelEnum.Debug, "Just another info message");
        }
    }
}
