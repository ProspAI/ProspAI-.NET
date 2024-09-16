using ProspAI_Sprint3.Models;
using ProspAI_Sprint3.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProspAI_Sprint3.Services
{
    public class FuncionarioService : IService<Funcionario>
    {
        private readonly IRepository<Funcionario> _funcionarioRepository;

        public FuncionarioService(IRepository<Funcionario> funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        public async Task<IEnumerable<Funcionario>> ObterTodosAsync()
        {
            return await _funcionarioRepository.ObterTodosAsync();
        }

        public async Task<Funcionario> ObterPorIdAsync(int id)
        {
            return await _funcionarioRepository.ObterPorIdAsync(id);
        }

        public async Task<Funcionario> AdicionarAsync(Funcionario funcionario)
        {
            return await _funcionarioRepository.AdicionarAsync(funcionario);
        }

        public async Task AtualizarAsync(Funcionario funcionario)
        {
            await _funcionarioRepository.AtualizarAsync(funcionario);
        }

        public async Task ExcluirAsync(int id)
        {
            await _funcionarioRepository.ExcluirAsync(id);
        }
    }
}