using Dependency_Injection.Services;
using Dependency_Injection.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dependency_Injection.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogController : ControllerBase
    {

        //private readonly ILogger<LogController> _logger;

        //public LogController(ILogger<LogController> logger)
        //{
        //    _logger = logger;
        //}
        readonly ILog _log;
        public LogController(ILog log)
        {
            _log = log;
        }

        public IActionResult Index()
        {
            //Ba??ml?l?k: ?uan ConsoleLog kullan?l?yor ama yar?n TextLog/vb. kullan?lmak istenirse buradaki kaynak kodu de?i?tirmek gerekecek.
            //ConsoleLog log = new ConsoleLog();
            //log.Log();

            _log.Log();

            return Ok();
        }

    }
}