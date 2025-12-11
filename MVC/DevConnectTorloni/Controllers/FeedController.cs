using System.Threading.Tasks;
using DevConnectTorloni.Contexts;
using DevConnectTorloni.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevConnectTorloni.Controllers
{
    public class FeedController : Controller
    {
        private readonly DevConnectContext _context;

        private readonly ILogger<FeedController> _logger;

        public FeedController(ILogger<FeedController> logger, DevConnectContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            List<Publicacao> publicacaos = await _context.Publicacao.Include(p => p.Usuario).ToListAsync();

            //listar as publis
            return View(publicacaos);
        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormCollection form)
        {
            Publicacao novaPublicacao = new Publicacao
            {
                Descricao = form["Descricao"].ToString(),
                //coloca a data que foi criada a publi
                DataPublicacao = DateOnly.FromDateTime(DateTime.Now)
            };

            if (form.Files.Count > 0)
            {
                var file = form.Files[0];
                var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                var path = Path.Combine(folder, file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                novaPublicacao.ImagemUrl = file.FileName;
            }

            try
            {
                _context.Publicacao.Add(novaPublicacao);

                await _context.SaveChangesAsync();

                ViewBag.PublicacaoCadastrada = "Cadastrada";

                return View(nameof(Index));
            }
            catch (System.Exception)
            {

                ViewBag.PublicacaoCadastrada = "Nao Cadastrada";
                
                return RedirectToAction(nameof(Index));
            }

        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}