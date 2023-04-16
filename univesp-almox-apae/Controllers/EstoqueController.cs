using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using univesp.almox.apae.Database;
using univesp.almox.apae.Models.Estoque;

namespace univesp.almox.apae.Controllers
{
    [Authorize]
    public class EstoqueController : Controller
    {
        private readonly ApplicationDatabase _database;

        public EstoqueController(ApplicationDatabase database)
        {
            _database = database;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await _database.Estoque
                .AsNoTracking()
                .Select(e => new EstoqueViewModel
                {
                    MaterialId = e.MaterialId,
                    Material = e.Material.Nome,
                    Quantidade = e.Quantidade,
                    Unidade = e.Medida.Sigla,
                    ValorMedio = e.ValorMedio
                })
                .ToListAsync();

            return View(model);
        }
    }
}
