using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using univesp.almox.apae.Database;
using univesp.almox.apae.Models.Saida;

namespace univesp.almox.apae.Controllers
{
    public class SaidaController : Controller
    {
        private readonly ApplicationDatabase _database;

        public SaidaController(ApplicationDatabase database)
        {
            _database = database;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Nova(int estoqueId)
        {
            var itemSaida = await _database.Estoque
                .Where(e => e.Id == estoqueId)
                .Select(e => new ItemSaidaViewModel
                {
                    Material = e.Material.Nome,
                    Medida = e.Medida.Nome,
                    MaterialId = e.MaterialId,
                    MedidaId = e.MedidaId,
                    Quantidade = e.Quantidade,
                })
                .FirstOrDefaultAsync();

            if (itemSaida == null)
                return NotFound();

            return View(new NovaSaidaViewModel
            {
                Data = DateTime.Now,
                ItemSaidaViewModel = itemSaida!
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Nova(NovaSaidaViewModel model)
        {
            if(ModelState.IsValid)
            {
                var estoque = await _database.Estoque.FindAsync(model.EstoqueId);

                if (estoque == null)
                    return NotFound();

                if (model.ItemSaidaViewModel.Quantidade > estoque.Quantidade)
                    return NotFound();
                
                estoque.Quantidade -= model.ItemSaidaViewModel.Quantidade;

                return RedirectToAction("index", "estoque");
            }

            return View(model);
        }
    }
}
