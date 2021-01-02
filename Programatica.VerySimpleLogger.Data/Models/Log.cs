using Programatica.Framework.Data.Models;

namespace Programatica.VerySimpleLogger.Data.Models
{
    public class Log : BaseModel
    {
        public string Caller { get; set; }
        public LogLevelEnum Level { get; set; }
        public string Message { get; set; }
    }

    public enum LogLevelEnum
    {
        Info=0,
        Debug=1,
        Error=2
    }
}
