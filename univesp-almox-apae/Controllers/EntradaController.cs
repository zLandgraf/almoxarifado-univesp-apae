using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using univesp.almox.apae.Database;
using univesp.almox.apae.Database.Domain;
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

        [HttpGet]
        public async Task<IActionResult> Index(IndexEntradaViewModel? model)
        {
            var entradas = await _database.ItemEntrada
                .AsNoTracking()
                .Where(e => model == null || EF.Functions.Like(e.Material.Nome, $"%{model.Query}%"))
                .Select(e => new EntradaViewModel
                {
                    Data = e.Entrada.Data.ToString("dd/MM/yyyy"),
                    Fornecedor = e.Entrada.Fornecedor,
                    Material = e.Material.Nome,
                    Quantidade = e.Quantidade,
                })
                .ToListAsync();

            if (model == null)
            {
                model = new IndexEntradaViewModel();
            }

            model.Entradas = entradas;
            return View(model);
        }

        [HttpGet]
        public IActionResult Nova()
        {
            return View(new NovaEntradaViewModel
            {
                Data = DateTime.Now,
                ItensEntradaModel = new List<ItemEntradaViewModel>()
                {
                    new ItemEntradaViewModel
                    {
                        Material = "",
                        Quantidade = 1,
                    }
                }
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Nova(NovaEntradaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var entrada = new Entrada
                {
                    Data = DateTime.UtcNow,
                    DocumentoFornecedor = model.DocumentoFornecedor,
                    Fornecedor = model.Fornecedor,
                    ItemEntrada = new List<ItemEntrada>()
                };

                foreach (var item in model.ItensEntradaModel)
                {
                    var material = await _database.Material
                        .Where(m => m.Nome == item.Material.ToLower())
                        .FirstOrDefaultAsync();

                    if(material == null)
                    {
                        material = new Material
                        {
                            Nome = item.Material.ToLower(),
                        };

                        await _database.Material.AddAsync(material);
                    }

                    var estoque = await _database.Estoque
                        .Where(e =>
                            e.MaterialId == material.Id &&
                            e.MedidaId == item.MedidaId)
                        .FirstOrDefaultAsync();

                    if(estoque == null)
                    {
                        estoque = new Estoque
                        {
                            Material = material,
                            MedidaId = item.MedidaId,
                            Quantidade = item.Quantidade,
                        };

                        await _database.Estoque.AddAsync(estoque);
                    }
                    else
                    {
                        estoque.Quantidade += item.Quantidade;
                        _database.Estoque.Update(estoque);
                    }

                    entrada.ItemEntrada.Add(new ItemEntrada
                    {
                        Material = material,
                        MedidaId = item.MedidaId,
                        Quantidade = item.Quantidade,
                    });

                    await _database.Entrada.AddAsync(entrada);
                }

                await _database.SaveChangesAsync();

                return RedirectToAction("Index", "Estoque");
            }

            return View(model);
        }
    }
}
