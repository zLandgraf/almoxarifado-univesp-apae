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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Nova(NovaEntradaViewModel model)
        {
            return View(model);
        }

        [HttpGet]
        public IActionResult Item(int indice)
        {
            var arr = new ItemEntradaViewModel[indice + 1];

            var item = new ItemEntradaViewModel
            {
                Material = "",
                Medida = "",
                Quantidade = 0,
                Valor = 0
            };

            arr[indice] = item;

            return PartialView("Views/Entrada/Partials/_itemEntrada.cshtml", new NovoItemEntradaViewModel
            {
                Index = indice,
                ItensEntradaModel = arr.ToList() 
            });
        }
    }
}
