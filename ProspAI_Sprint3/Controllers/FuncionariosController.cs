using Microsoft.AspNetCore.Mvc;
using ProspAI_Sprint3.Models;
using ProspAI_Sprint3.Models.DTOs;  
using ProspAI_Sprint3.Services;
using System.Threading.Tasks;

namespace ProspAI_Sprint3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FuncionarioController : ControllerBase
    {
        private readonly IService<Funcionario> _funcionarioService;

        public FuncionarioController(IService<Funcionario> funcionarioService)
        {
            _funcionarioService = funcionarioService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var funcionarios = await _funcionarioService.ObterTodosAsync();
            var funcionariosDTO = funcionarios.Select(f => new FuncionarioDTO
            {
                Id_fun = f.Id_fun,
                Nome_fun = f.Nome_fun,
                Email_fun = f.Email_fun,
                Data_admissao = f.Data_admissao
            });
            return Ok(funcionariosDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var funcionario = await _funcionarioService.ObterPorIdAsync(id);
            if (funcionario == null)
            {
                return NotFound();
            }

            var funcionarioDTO = new FuncionarioDTO
            {
                Id_fun = funcionario.Id_fun,
                Nome_fun = funcionario.Nome_fun,
                Email_fun = funcionario.Email_fun,
                Data_admissao = funcionario.Data_admissao
            };

            return Ok(funcionarioDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] FuncionarioDTO funcionarioDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var funcionario = new Funcionario
            {
                Nome_fun = funcionarioDTO.Nome_fun,
                Email_fun = funcionarioDTO.Email_fun,
                Data_admissao = funcionarioDTO.Data_admissao,
                // Defina uma senha padrão ou deixe-a para ser configurada em outro fluxo
                Senha_fun = "SenhaPadrão"
            };

            var funcionarioCriado = await _funcionarioService.AdicionarAsync(funcionario);
            return CreatedAtAction(nameof(ObterPorId), new { id = funcionarioCriado.Id_fun }, funcionarioDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] FuncionarioDTO funcionarioDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != funcionarioDTO.Id_fun)
            {
                return BadRequest();
            }

            var funcionario = new Funcionario
            {
                Id_fun = funcionarioDTO.Id_fun,
                Nome_fun = funcionarioDTO.Nome_fun,
                Email_fun = funcionarioDTO.Email_fun,
                Data_admissao = funcionarioDTO.Data_admissao,
                // A senha não é atualizada aqui para segurança
            };

            await _funcionarioService.AtualizarAsync(funcionario);
            return NoContent();
        }
    }
}
