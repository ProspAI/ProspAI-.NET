using Microsoft.AspNetCore.Mvc;
using ProspAI_Sprint3.Persistencia.Services;
using ProspAI_Sprint3.Models;

namespace ProspAI_Sprint3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReclamacaoPredictionController : ControllerBase
    {
        private readonly ReclamacaoPredictionService _predictionService;

        public ReclamacaoPredictionController(ReclamacaoPredictionService predictionService)
        {
            _predictionService = predictionService;
        }

        /// <summary>
        /// Faz a predição do número de reclamações solucionadas.
        /// </summary>
        /// <param name="input">Dados do desempenho do funcionário</param>
        /// <returns>Número previsto de reclamações solucionadas</returns>
        [HttpPost("predict")]
        [ProducesResponseType(typeof(float), 200)]
        public IActionResult Predict([FromBody] FuncionarioDesempenhoInput input)
        {
            if (input == null)
            {
                return BadRequest("Dados de entrada inválidos.");
            }

            var predictedValue = _predictionService.PredictReclamacoesSolu(
                input.FuncionarioId,
                input.ReclamacoesResp,
                input.DesempenhoGeral
            );

            return Ok(predictedValue);
        }
    }

    public class FuncionarioDesempenhoInput
    {
        public float FuncionarioId { get; set; }
        public float ReclamacoesResp { get; set; }
        public float DesempenhoGeral { get; set; }
    }
}
