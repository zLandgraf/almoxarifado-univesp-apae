using Microsoft.AspNetCore.Mvc;

namespace univesp.almox.apae.Controllers
{
    public class RelatorioController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
