using Microsoft.AspNetCore.Mvc;
using Programatica.Framework.Data.Repository;
using Programatica.Framework.Mvc.Controllers;
using Programatica.VerySimpleLogger.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Programatica.VerySimpleLogger.Controllers
{
    public class LogManagerController : EJ2DataGridBaseController<Log>
    {
        public readonly IRepository<Log> _logRepository;

        public LogManagerController(IRepository<Log> logRepository)
        {
            _logRepository = logRepository;
        }

        protected override async Task<IEnumerable<Log>> LoadDataAsync()
        {
            var data = await _logRepository.GetDataAsync();
            return data;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
