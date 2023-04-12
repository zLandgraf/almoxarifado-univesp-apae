using Microsoft.AspNetCore.Mvc;
using univesp.almox.apae.Database;

namespace univesp.almox.apae.Controllers
{
    public class EntradaController : Controller
    {
        private readonly ApplicationDatabase _database;

        public EntradaController(ApplicationDatabase database)
        {
            _database = database;
        }

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
