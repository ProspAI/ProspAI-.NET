using Microsoft.AspNetCore.Mvc;
using ProspAI_Sprint3.Models;
using ProspAI_Sprint3.Services;
using ProspAI_Sprint3.DTO; 

namespace ProspAI_Sprint3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesempenhoController : ControllerBase
    {
        private readonly IService<Desempenho> _desempenhoService;
        private readonly IService<Funcionario> _funcionarioService;

        public DesempenhoController(IService<Desempenho> desempenhoService, IService<Funcionario> funcionarioService)
        {
            _desempenhoService = desempenhoService;
            _funcionarioService = funcionarioService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var desempenhos = await _desempenhoService.ObterTodosAsync();
            return Ok(desempenhos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var desempenho = await _desempenhoService.ObterPorIdAsync(id);
            if (desempenho == null)
                return NotFound();
            return Ok(desempenho);
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] DesempenhoCreateDTO desempenhoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var funcionario = await _funcionarioService.ObterPorIdAsync(desempenhoDto.Id_fun);
            if (funcionario == null)
                return BadRequest("Funcionário não encontrado.");

            var desempenho = new Desempenho
            {
                Mes_desem = desempenhoDto.Mes_desem,
                Reclamacoes_resp = desempenhoDto.Reclamacoes_resp,
                Reclamacoes_solu = desempenhoDto.Reclamacoes_solu,
                Id_fun = desempenhoDto.Id_fun,
                Funcionario = funcionario
            };

            var desempenhoCriado = await _desempenhoService.AdicionarAsync(desempenho);
            return CreatedAtAction(nameof(ObterPorId), new { id = desempenhoCriado.Id_desem }, desempenhoCriado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] DesempenhoCreateDTO desempenhoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id <= 0)
                return BadRequest();

            var funcionario = await _funcionarioService.ObterPorIdAsync(desempenhoDto.Id_fun);
            if (funcionario == null)
                return BadRequest("Funcionário não encontrado.");

            var desempenho = new Desempenho
            {
                Id_desem = id,
                Mes_desem = desempenhoDto.Mes_desem,
                Reclamacoes_resp = desempenhoDto.Reclamacoes_resp,
                Reclamacoes_solu = desempenhoDto.Reclamacoes_solu,
                Id_fun = desempenhoDto.Id_fun,
                Funcionario = funcionario
            };

            await _desempenhoService.AtualizarAsync(desempenho);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            var desempenho = await _desempenhoService.ObterPorIdAsync(id);
            if (desempenho == null)
                return NotFound();

            await _desempenhoService.ExcluirAsync(id);
            return NoContent();
        }
    }
}
