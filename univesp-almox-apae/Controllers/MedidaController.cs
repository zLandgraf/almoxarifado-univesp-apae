using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using univesp.almox.apae.Database;
using univesp.almox.apae.Database.Domain;
using univesp.almox.apae.Models.Medida;
using univesp.almox.apae.Models.Saida;

namespace univesp.almox.apae.Controllers
{
    public class MedidaController : Controller
    {
        private readonly ApplicationDatabase _database;

        public MedidaController(ApplicationDatabase database)
        {
            _database = database;
        }

        [HttpGet]
        public async Task<IActionResult> Index(IndexMedidaViewModel? model)
        {
            var medidas = await _database.Medida
                .AsNoTracking()
                .Where(e => model == null || EF.Functions.Like(e.Nome, $"%{model.Query}%"))
                .Select(e => new Medida
                {
                   Id = e.Id,
                   Nome = e.Nome,
                   Sigla = e.Sigla,
                })
                .ToListAsync();

            if (model == null)
            {
                model = new IndexMedidaViewModel();
            }

            model.Medidas = medidas;
            return View(model);
        }

        [HttpGet]
        public IActionResult Nova()
        {
            return View(new NovaMedidaViewModel());
        }

        [HttpPost]
        public IActionResult Nova(NovaMedidaViewModel model)
        {
            if(ModelState.IsValid)
            {
            }

            return View();
        }

    }
}
