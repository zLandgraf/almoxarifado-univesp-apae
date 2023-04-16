using Microsoft.AspNetCore.Mvc;
using univesp.almox.apae.Database;
using univesp.almox.apae.Models.Entrada;

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
            return View(new NovaEntradaViewModel
            {
                Data = DateTime.Now,
            });
        }

        [HttpGet]
        public IActionResult Item(int indice)
        {
            return PartialView("Views/Entrada/Partials/_itemEntrada.cshtml", indice);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Nova(NovaEntradaViewModel model)
        {
            return View(model);
        }
    }
}
