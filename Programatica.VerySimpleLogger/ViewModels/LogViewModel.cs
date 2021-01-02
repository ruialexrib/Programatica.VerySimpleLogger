using Programatica.Framework.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Programatica.VerySimpleLogger.ViewModels
{
    public class LogViewModel : BaseModel
    {
        public string Level { get; set; }
        public string Caller { get; set; }
        public string Message { get; set; }
    }
}
