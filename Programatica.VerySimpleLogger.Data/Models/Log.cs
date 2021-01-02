using Programatica.Framework.Data.Models;

namespace Programatica.VerySimpleLogger.Data.Models
{
    public class Log : BaseModel
    {
        public string Caller { get; set; }
        public string Level { get; set; }
        public string Message { get; set; }
    }
}
