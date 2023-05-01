using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using univesp.almox.apae.Database;
using univesp.almox.apae.Database.Domain;
using univesp.almox.apae.Models.Entrada;
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

        [HttpGet]
        public async Task<IActionResult> Index(IndexSaidaViewModel? model)
        {
            var saidas = await _database.ItemSaida
                .AsNoTracking()
                .Where(e => model == null || EF.Functions.Like(e.Material.Nome, $"%{model.Query}%"))
                .Select(e => new SaidaViewModel
                {
                    Data = e.Saida.Data.ToString("dd/MM/yyyy"),
                    Requisitante = e.Saida.Requisitante,
                    Material = e.Material.Nome,
                    Quantidade = e.Quantidade,
                })
                .ToListAsync();

            if (model == null)
            {
                model = new IndexSaidaViewModel();
            }

            model.Saidas = saidas;
            return View(model);
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

                var saida = new Saida
                {
                    Data = DateTime.UtcNow,
                    Requisitante = model.Requisitante,
                    ItensSaida = new List<ItemSaida>
                    {
                        new ItemSaida
                        {
                            MaterialId = model.ItemSaidaViewModel.MaterialId,
                            MedidaId = model.ItemSaidaViewModel.MedidaId,
                            Quantidade = model.ItemSaidaViewModel.Quantidade,
                        }
                    }
                };

                estoque.Quantidade -= model.ItemSaidaViewModel.Quantidade;

                await _database.Saida.AddAsync(saida);
                _database.Estoque.Update(estoque);
                
                await _database.SaveChangesAsync();

                return RedirectToAction("index", "estoque");
            }

            return View(model);
        }
    }
}
