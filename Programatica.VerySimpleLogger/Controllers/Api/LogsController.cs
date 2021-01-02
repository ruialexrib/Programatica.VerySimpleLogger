using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Programatica.Framework.Data.Repository;
using Programatica.Framework.Services;
using Programatica.VerySimpleLogger.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Programatica.VerySimpleLogger.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private readonly IRepository<Log> _logRepository;

        public LogsController(IRepository<Log> logRepository)
        {
            _logRepository = logRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Log log)
        {
            await _logRepository.InsertAsync(log);
            return Ok();
        }
    }

}
