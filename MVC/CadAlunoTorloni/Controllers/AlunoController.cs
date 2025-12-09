using CadAlunoTorloni.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace CadAlunoTorloni.Controllers
{
    public class AlunoController : Controller
    {
        //     private static List<Aluno> Alunos = new List<Aluno>
        // {
        //     new Aluno{ Id = 1, Nome = "Livia", Idade = "16", Cpf = "00000-00"},
        //     new Aluno{ Id = 2, Nome = "Amy Lee", Idade = "17", Cpf = "00000-01"},
        //     new Aluno{ Id = 3, Nome = "James", Idade = "17", Cpf = "00000-02"},
        //     new Aluno{ Id = 4, Nome = "Henrique", Idade = "17", Cpf = "00000-03"},
        //     new Aluno{ Id = 5, Nome = "Pedro Enzo", Idade = "17", Cpf = "00000-04"}
        // };


        private readonly CadAlunoTorloniContext _context;
        private readonly ILogger<AlunoController> _logger;
        public AlunoController(ILogger<AlunoController> logger, CadAlunoTorloniContext context)
        {
            _logger = logger;
            _context = context;
        }

        // public IActionResult Index()
        // {
        //     return View(Alunos);
        // }

        public async Task<IActionResult> Index()
        {
            var alunos = await _context.Alunos.ToListAsync();
            return View(alunos);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Aluno aluno)
        {
            // aluno.Id = Alunos.Max(a => a.Id) + 1;
            // Alunos.Add(aluno);
            _context.Add(aluno);
            await _context.SaveChangesAsync();
            
            return RedirectToAction(nameof (Index));
        }
    }
}