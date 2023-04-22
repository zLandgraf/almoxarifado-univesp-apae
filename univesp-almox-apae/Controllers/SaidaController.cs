using Microsoft.AspNetCore.Mvc;
using univesp.almox.apae.Models.Saida;

namespace univesp.almox.apae.Controllers
{
    public class SaidaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Nova()
        {
            return View(new NovaSaidaViewModel
            {
                Data = DateTime.Now,
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Nova(NovaSaidaViewModel model)
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction("index", "estoque");
            }

            return View(model);
        }
    }
}
