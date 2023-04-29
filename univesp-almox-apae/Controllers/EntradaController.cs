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
                ItensEntradaModel = new List<ItemEntradaViewModel>()
                {
                    new ItemEntradaViewModel
                    {
                        Material = "",
                        Medida = "",
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

                    var medida = await _database.Medida
                        .Where(u => u.Nome == item.Medida.ToLower())
                        .FirstOrDefaultAsync();

                    if(medida == null)
                    {
                        medida = new Medida
                        {
                            Nome = item.Medida.ToLower(),
                        };

                        await _database.Medida.AddAsync(medida);
                    }

                    var estoque = await _database.Estoque
                        .Where(e =>
                            e.MaterialId == material.Id &&
                            e.MedidaId == medida.Id)
                        .FirstOrDefaultAsync();

                    if(estoque == null)
                    {
                        estoque = new Estoque
                        {
                            Material = material,
                            Medida = medida,
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
                        Medida = medida,
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
