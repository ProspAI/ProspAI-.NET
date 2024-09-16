using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProspAI_Sprint3.Services
{
    public interface IService<T> where T : class
    {
        Task<IEnumerable<T>> ObterTodosAsync();
        Task<T> ObterPorIdAsync(int id);
        Task<T> AdicionarAsync(T entity);
        Task AtualizarAsync(T entity);
        Task ExcluirAsync(int id);
    }
}