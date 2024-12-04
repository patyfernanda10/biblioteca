using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

public class EmprestimosController : Controller
{
    private readonly ApplicationDbContext _context;

    public EmprestimosController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var emprestimos = _context.Emprestimos.Include(e => e.Livro).ToList();
        return View(emprestimos);
    }

    [HttpPost]
    public IActionResult Emprestar(int livroId, string usuario)
    {
        var livro = _context.Livros.Find(livroId);
        if (livro != null && livro.Disponivel)
        {
            livro.Disponivel = false;
            var emprestimo = new Emprestimo
            {
                LivroId = livroId,
                Usuario = usuario,
                DataEmprestimo = DateTime.Now
            };
            _context.Emprestimos.Add(emprestimo);
            _context.SaveChanges();
        }
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Devolver(int emprestimoId)
    {
        var emprestimo = _context.Emprestimos.Find(emprestimoId);
        if (emprestimo != null)
        {
            emprestimo.DataDevolucao = DateTime.Now;
            var livro = _context.Livros.Find(emprestimo.LivroId);
            if (livro != null)
            {
                livro.Disponivel = true;
            }
            _context.SaveChanges();
        }
        return RedirectToAction("Index");
    }
}
