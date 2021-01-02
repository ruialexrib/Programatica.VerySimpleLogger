using Programatica.VerySimpleLogger.Data.Models;
using System.Threading.Tasks;

namespace Programatica.VerySimpleLogger.Client.Test
{
    class Program
    {
        static async Task Main(string[] args)
        {
            VerySimpleLogger.ServerUrl = "https://localhost:44339/api/logs/";
            await VerySimpleLogger.LogAsync("Main", LogLevelEnum.Debug, "Just another info message");
        }
    }
}
