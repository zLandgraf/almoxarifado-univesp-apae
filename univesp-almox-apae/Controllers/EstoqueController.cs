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
        public async Task<IActionResult> Index(IndexEstoqueViewModel? model)
        {
            var estoques = await _database.Estoque
                .AsNoTracking()
                .Where(e => model != null 
                    ? EF.Functions.Like(e.Material.Nome, $"%{model.Query}%") 
                    : true)
                .Select(e => new EstoqueViewModel
                {
                    Id = e.Id,
                    MaterialId = e.MaterialId,
                    Material = e.Material.Nome,
                    Medida = e.Medida.Nome,
                    Quantidade = e.Quantidade,
                })
                .ToListAsync();

            if(model == null)
            {
                model = new IndexEstoqueViewModel();
            }

            model.Estoques = estoques;
            return View(model);
        }
    }
}
