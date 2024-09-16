using Microsoft.EntityFrameworkCore;
using ProspAI_Sprint3.Models;

namespace ProspAI_Sprint3.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Reclamacao> Reclamacoes { get; set; }
        public DbSet<Desempenho> Desempenhos { get; set; }
    }
}