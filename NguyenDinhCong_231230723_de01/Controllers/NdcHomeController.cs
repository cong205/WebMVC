using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NguyenDinhCong_231230723_de01.Models;

namespace NguyenDinhCong_231230723_de01.Controllers
{
    public class NdcHomeController : Controller
    {
        private readonly ILogger<NdcHomeController> _logger;

        public NdcHomeController(ILogger<NdcHomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult NdcIndex()
        {
            return View();
        }

        public IActionResult NdcPrivacy()
        {
            return View();
        }
        public IActionResult NdcContact()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
