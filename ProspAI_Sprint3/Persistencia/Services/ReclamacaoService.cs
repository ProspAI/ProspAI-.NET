using ProspAI_Sprint3.Models;
using ProspAI_Sprint3.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProspAI_Sprint3.Services
{
    public class ReclamacaoService : IService<Reclamacao>
    {
        private readonly IRepository<Reclamacao> _reclamacaoRepository;

        public ReclamacaoService(IRepository<Reclamacao> reclamacaoRepository)
        {
            _reclamacaoRepository = reclamacaoRepository;
        }

        public async Task<IEnumerable<Reclamacao>> ObterTodosAsync()
        {
            return await _reclamacaoRepository.ObterTodosAsync();
        }

        public async Task<Reclamacao> ObterPorIdAsync(int id)
        {
            return await _reclamacaoRepository.ObterPorIdAsync(id);
        }

        public async Task<Reclamacao> AdicionarAsync(Reclamacao reclamacao)
        {
            return await _reclamacaoRepository.AdicionarAsync(reclamacao);
        }

        public async Task AtualizarAsync(Reclamacao reclamacao)
        {
            await _reclamacaoRepository.AtualizarAsync(reclamacao);
        }

        public async Task ExcluirAsync(int id)
        {
            await _reclamacaoRepository.ExcluirAsync(id);
        }
    }
}