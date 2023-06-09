﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using univesp.almox.apae.Database;
using univesp.almox.apae.Database.Domain;
using univesp.almox.apae.Models.Medida;

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
        public async Task<IActionResult> Nova(NovaMedidaViewModel model)
        {
            if(ModelState.IsValid)
            {
                var nomeEmUso = await _database.Medida.AnyAsync(m => m.Nome == model.Nome);

                if (nomeEmUso)
                    return BadRequest();

                var siglaEmUso = await _database.Medida.AnyAsync(m => m.Sigla == model.Sigla);

                if (siglaEmUso)
                    return BadRequest();

                var medida = new Medida
                {
                    Nome = model.Nome,
                    Sigla = model.Sigla
                };

                await _database.Medida.AddAsync(medida);
                await _database.SaveChangesAsync();

                return RedirectToAction("index", "medida");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<JsonResult> Select2([FromQuery] string? search, int? pagina)
        {
            pagina = pagina ?? 1;
            var registrosPorPagina = 5;

            var resultados = await _database.Medida
                .AsNoTracking()
                .Where(m => EF.Functions.Like(m.Nome, $"%{search}%") || EF.Functions.Like(m.Sigla, $"%{search}%"))
                .Select(x => new
                {
                    Id = x.Id,
                    Text = x.Nome
                })
                .OrderByDescending(x => x.Id)
                .Skip((pagina.Value - 1) * registrosPorPagina)
                .Take(registrosPorPagina)
                .ToListAsync();

            var totalRegistros = await _database.Medida
                .AsNoTracking()
                .Where(m => EF.Functions.Like(m.Nome, $"%{search}%") || EF.Functions.Like(m.Sigla, $"%{search}%"))
                .CountAsync();

            var response = new 
            {
                results = resultados,
                total_count = totalRegistros
            };

            return new JsonResult(response);
        }
    }
}
