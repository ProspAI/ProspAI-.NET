using ProspAI_Sprint3.Models;
using ProspAI_Sprint3.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProspAI_Sprint3.Services
{
    public class DesempenhoService : IService<Desempenho>
    {
        private readonly IRepository<Desempenho> _desempenhoRepository;

        public DesempenhoService(IRepository<Desempenho> desempenhoRepository)
        {
            _desempenhoRepository = desempenhoRepository;
        }

        public async Task<IEnumerable<Desempenho>> ObterTodosAsync()
        {
            return await _desempenhoRepository.ObterTodosAsync();
        }

        public async Task<Desempenho> ObterPorIdAsync(int id)
        {
            return await _desempenhoRepository.ObterPorIdAsync(id);
        }

        public async Task<Desempenho> AdicionarAsync(Desempenho desempenho)
        {
            return await _desempenhoRepository.AdicionarAsync(desempenho);
        }

        public async Task AtualizarAsync(Desempenho desempenho)
        {
            await _desempenhoRepository.AtualizarAsync(desempenho);
        }

        public async Task ExcluirAsync(int id)
        {
            await _desempenhoRepository.ExcluirAsync(id);
        }
    }
}