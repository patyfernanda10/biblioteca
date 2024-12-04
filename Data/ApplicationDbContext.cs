using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;


namespace WebApplication1.Data
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public required DbSet<Livro> Livros { get; set; }
        public required DbSet<Usuario> Usuarios { get; set; }
        public required DbSet<Emprestimo> Emprestimos { get; set; }
    }
}