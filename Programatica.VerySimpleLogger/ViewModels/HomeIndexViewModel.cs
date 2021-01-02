using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Programatica.VerySimpleLogger.ViewModels
{
    public class HomeIndexViewModel
    {
        public int AllCount { get; set; }
        public int InfoCount { get; set; }
        public int DebugCount { get; set; }
        public int ErrorCount { get; set; }
        public string ServerUrl { get; set; }
    }
}
