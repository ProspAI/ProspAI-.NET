using Microsoft.AspNetCore.Mvc;
using ProspAI_Sprint3.Models;
using ProspAI_Sprint3.Models.DTOs; // Importar o namespace DTO
using ProspAI_Sprint3.Services;
using System.Linq;
using System.Threading.Tasks;

namespace ProspAI_Sprint3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReclamacaoController : ControllerBase
    {
        private readonly IService<Reclamacao> _reclamacaoService;

        public ReclamacaoController(IService<Reclamacao> reclamacaoService)
        {
            _reclamacaoService = reclamacaoService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodas()
        {
            var reclamacoes = await _reclamacaoService.ObterTodosAsync();
            var reclamacoesDTO = reclamacoes.Select(r => new ReclamacaoDTO
            {
                Id_recla = r.Id_recla,
                Nm_clie = r.Nm_clie,
                Dt_recla = r.Dt_recla,
                Origem_recla = r.Origem_recla,
                Solucionada_recla = r.Solucionada_recla,
                Assunto_recla = r.Assunto_recla,
                Id_fun = r.Id_fun
            });
            return Ok(reclamacoesDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var reclamacao = await _reclamacaoService.ObterPorIdAsync(id);
            if (reclamacao == null)
                return NotFound();

            var reclamacaoDTO = new ReclamacaoDTO
            {
                Id_recla = reclamacao.Id_recla,
                Nm_clie = reclamacao.Nm_clie,
                Dt_recla = reclamacao.Dt_recla,
                Origem_recla = reclamacao.Origem_recla,
                Solucionada_recla = reclamacao.Solucionada_recla,
                Assunto_recla = reclamacao.Assunto_recla,
                Id_fun = reclamacao.Id_fun
            };

            return Ok(reclamacaoDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] ReclamacaoDTO reclamacaoDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var reclamacao = new Reclamacao
            {
                Nm_clie = reclamacaoDTO.Nm_clie,
                Dt_recla = reclamacaoDTO.Dt_recla,
                Origem_recla = reclamacaoDTO.Origem_recla,
                Solucionada_recla = reclamacaoDTO.Solucionada_recla,
                Assunto_recla = reclamacaoDTO.Assunto_recla,
                Id_fun = reclamacaoDTO.Id_fun
            };

            var reclamacaoCriada = await _reclamacaoService.AdicionarAsync(reclamacao);
            return CreatedAtAction(nameof(ObterPorId), new { id = reclamacaoCriada.Id_recla }, reclamacaoDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] ReclamacaoDTO reclamacaoDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != reclamacaoDTO.Id_recla)
                return BadRequest();

            var reclamacao = new Reclamacao
            {
                Id_recla = reclamacaoDTO.Id_recla,
                Nm_clie = reclamacaoDTO.Nm_clie,
                Dt_recla = reclamacaoDTO.Dt_recla,
                Origem_recla = reclamacaoDTO.Origem_recla,
                Solucionada_recla = reclamacaoDTO.Solucionada_recla,
                Assunto_recla = reclamacaoDTO.Assunto_recla,
                Id_fun = reclamacaoDTO.Id_fun
            };

            await _reclamacaoService.AtualizarAsync(reclamacao);
            return NoContent();
        }
    }
}
