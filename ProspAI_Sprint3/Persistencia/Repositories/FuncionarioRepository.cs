using ProspAI_Sprint3.Data;
using ProspAI_Sprint3.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProspAI_Sprint3.Repositories
{
    public class FuncionarioRepository : IRepository<Funcionario>
    {
        private readonly ApplicationDbContext _context;

        public FuncionarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Funcionario>> ObterTodosAsync()
        {
            return await _context.Funcionarios.ToListAsync();
        }

        public async Task<Funcionario> ObterPorIdAsync(int id)
        {
            return await _context.Funcionarios.FindAsync(id);
        }

        public async Task<Funcionario> AdicionarAsync(Funcionario funcionario)
        {
            await _context.Funcionarios.AddAsync(funcionario);
            await _context.SaveChangesAsync();
            return funcionario;
        }

        public async Task AtualizarAsync(Funcionario funcionario)
        {
            _context.Entry(funcionario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task ExcluirAsync(int id)
        {
            var funcionario = await _context.Funcionarios.FindAsync(id);
            if (funcionario != null)
            {
                _context.Funcionarios.Remove(funcionario);
                await _context.SaveChangesAsync();
            }
        }
    }
}