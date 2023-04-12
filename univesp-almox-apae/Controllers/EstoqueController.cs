using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using univesp.almox.apae.Database;

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
        public IActionResult Index()
        {
            return View();
        }
    }
}
