using ProspAI_Sprint3.Data;
using ProspAI_Sprint3.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProspAI_Sprint3.Repositories
{
    public class ReclamacaoRepository : IRepository<Reclamacao>
    {
        private readonly ApplicationDbContext _context;

        public ReclamacaoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Reclamacao>> ObterTodosAsync()
        {
            return await _context.Reclamacoes.Include(r => r.Funcionario).ToListAsync();
        }

        public async Task<Reclamacao> ObterPorIdAsync(int id)
        {
            return await _context.Reclamacoes.Include(r => r.Funcionario).FirstOrDefaultAsync(r => r.Id_recla == id);
        }

        public async Task<Reclamacao> AdicionarAsync(Reclamacao reclamacao)
        {
            await _context.Reclamacoes.AddAsync(reclamacao);
            await _context.SaveChangesAsync();
            return reclamacao;
        }

        public async Task AtualizarAsync(Reclamacao reclamacao)
        {
            _context.Entry(reclamacao).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task ExcluirAsync(int id)
        {
            var reclamacao = await _context.Reclamacoes.FindAsync(id);
            if (reclamacao != null)
            {
                _context.Reclamacoes.Remove(reclamacao);
                await _context.SaveChangesAsync();
            }
        }
    }
}