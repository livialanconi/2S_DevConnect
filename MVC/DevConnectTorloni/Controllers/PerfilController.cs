using Microsoft.AspNetCore.Mvc;

namespace DevConnectTorloni.Controllers
{
    public class PerfilController : Controller
    {
        private readonly ILogger<PerfilController> _logger;

        public PerfilController(ILogger<PerfilController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}