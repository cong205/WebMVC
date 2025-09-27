using Microsoft.AspNetCore.Mvc;

namespace layout.Controllers
{
    public class AdminHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
