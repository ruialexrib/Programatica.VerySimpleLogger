using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Programatica.Framework.Data.Repository;
using Programatica.Framework.Mvc.Controllers;
using Programatica.VerySimpleLogger.Data.Models;
using Programatica.VerySimpleLogger.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Programatica.VerySimpleLogger.Controllers
{
    public class LogManagerController : EJ2DataGridBaseController<LogViewModel>
    {
        public readonly IRepository<Log> _logRepository;
        public readonly IHostApplicationLifetime _hostApplicationLifetime;

        public LogManagerController(IRepository<Log> logRepository, IHostApplicationLifetime hostApplicationLifetime)
        {
            _logRepository = logRepository;
            _hostApplicationLifetime = hostApplicationLifetime;
        }

        protected override async Task<IEnumerable<LogViewModel>> LoadDataAsync()
        {
            return (await _logRepository.GetDataAsync())
                                        .Select(s => new LogViewModel
                                            {
                                                Id = s.Id,
                                                Caller = s.Caller,
                                                Level = s.Level.ToString(),
                                                Message = s.Message,
                                                CreatedDate = s.CreatedDate
                                            });
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Restart()
        {
            _hostApplicationLifetime.StopApplication();
            return RedirectToAction("Index", "Home");
        }
    }
}
