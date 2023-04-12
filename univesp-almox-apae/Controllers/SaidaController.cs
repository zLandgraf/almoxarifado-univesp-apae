using Microsoft.AspNetCore.Mvc;

namespace univesp.almox.apae.Controllers
{
    public class SaidaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Nova()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Nova(object model)
        {
            return View(model);
        }
    }
}
