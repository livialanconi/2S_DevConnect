using System.Runtime.CompilerServices;
using CadAlunoTorloni.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CadAlunoTorloni.Controllers
{
    public class FrutasController : Controller
    {
        private readonly ILogger<FrutasController> _logger;
        private readonly CadAlunoTorloniContext _context;

        public FrutasController(ILogger<FrutasController> logger, CadAlunoTorloniContext context)
        {
            _logger = logger;
            _context = context;
        }


        //criar uma lista de frutas
        //citricas
        //tropicais

        // private static List<Fruta> frutas = new List<Fruta>
        // {
        //     new Fruta{ Id = 1, Nome = "Maça", Cor = "Vermelha", Categoria = "Tropical"},
        //     new Fruta{ Id = 2, Nome = "Banana", Cor = "Amarela", Categoria = "Tropical"},
        //     new Fruta{ Id = 3, Nome = "Uva", Cor = "Roxa", Categoria = "Tropical"},
        //     new Fruta{ Id = 4, Nome = "Limão", Cor = "Verde", Categoria = "Cítrica"},
        //     new Fruta{ Id = 5, Nome = "Abacaxi", Cor = "Amarela", Categoria = "Cítrica"},
            

        // };

        public async Task<IActionResult> Index()
        {
            var frutas = await _context.Fruta.ToListAsync();
            return View(frutas);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Fruta fruta)
        {
            // //cria o proximo ID
            // fruta.Id = frutas.Max(f => f.Id) + 1;
            // //salvar no array
            // frutas.Add(fruta);
            //redirecionar o usuario para a Index
            return RedirectToAction("Index");
        }

        // public IActionResult FrutasCitricas()
        // {
        //     return View(frutas);
        // }
        
        public IActionResult FrutasTropicais()
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