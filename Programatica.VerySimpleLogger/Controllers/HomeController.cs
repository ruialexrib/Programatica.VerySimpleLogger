using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Programatica.VerySimpleLogger.ViewModels;
using Programatica.Framework.Mvc.Controllers;
using Programatica.Framework.Data.Repository;
using Programatica.VerySimpleLogger.Data.Models;
using System.Linq;
using Microsoft.AspNetCore.Hosting;

namespace Programatica.VerySimpleLogger.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IRepository<Log> _logRepository;
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public HomeController(
            IRepository<Log> logRepository,
            IWebHostEnvironment hostingEnvironment,
            ILogger<HomeController> logger)
        {
            _logRepository = logRepository;
            _hostingEnvironment = hostingEnvironment;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var logs = await _logRepository.GetDataAsync();
            var model = new HomeIndexViewModel
            {
                AllCount = logs.Count(),
                InfoCount = logs.Where(x => x.Level == LogLevelEnum.Info).Count(),
                DebugCount = logs.Where(x => x.Level == LogLevelEnum.Debug).Count(),
                ErrorCount = logs.Where(x => x.Level == LogLevelEnum.Error).Count(),
                ServerUrl = $"{Request.Scheme}://{Request.Host.Value}/api/logs/"
            };

            return View(model);
        }

        public async Task<IActionResult> License()
        {
            return await Task.Run(() => View());
        }

        public async Task<IActionResult> Credits()
        {
            return await Task.Run(() => View());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Error()
        {
            return await Task.Run(() => View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            }));
        }
    }
}
