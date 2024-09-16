using ProspAI_Sprint3.Data;
using ProspAI_Sprint3.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProspAI_Sprint3.Repositories
{
    public class DesempenhoRepository : IRepository<Desempenho>
    {
        private readonly ApplicationDbContext _context;

        public DesempenhoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Desempenho>> ObterTodosAsync()
        {
            return await _context.Desempenhos.Include(d => d.Funcionario).ToListAsync();
        }

        public async Task<Desempenho> ObterPorIdAsync(int id)
        {
            return await _context.Desempenhos.Include(d => d.Funcionario).FirstOrDefaultAsync(d => d.Id_desem == id);
        }

        public async Task<Desempenho> AdicionarAsync(Desempenho desempenho)
        {
            await _context.Desempenhos.AddAsync(desempenho);
            await _context.SaveChangesAsync();
            return desempenho;
        }

        public async Task AtualizarAsync(Desempenho desempenho)
        {
            _context.Entry(desempenho).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task ExcluirAsync(int id)
        {
            var desempenho = await _context.Desempenhos.FindAsync(id);
            if (desempenho != null)
            {
                _context.Desempenhos.Remove(desempenho);
                await _context.SaveChangesAsync();
            }
        }
    }
}