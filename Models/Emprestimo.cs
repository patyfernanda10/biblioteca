namespace WebApplication1.Models;
public class Emprestimo
{
    public int Id { get; set; }
    public int LivroId { get; set; }
    public string ?Usuario { get; set; }
    public DateTime DataEmprestimo { get; set; }
    public DateTime DataDevolucao { get; set; }
    public Livro? Livro { get; set; }
}
