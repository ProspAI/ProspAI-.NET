using Microsoft.ML;
using ProspAI_Sprint3.Models;

namespace ProspAI_Sprint3.Persistencia.Services
{
    public class ReclamacaoPredictionService
    {
        private readonly ITransformer _model;
        private readonly MLContext _mlContext;

        public ReclamacaoPredictionService()
        {
            _mlContext = new MLContext();
            // Carregar o modelo salvo
            DataViewSchema modelSchema;
            _model = _mlContext.Model.Load("Data/ModeloReclamacoes.zip", out modelSchema);
        }

        public float PredictReclamacoesSolu(float funcionarioId, float reclamacoesResp, float desempenhoGeral)
        {
            var input = new FuncionarioDesempenho
            {
                FuncionarioId = funcionarioId,
                ReclamacoesResp = reclamacoesResp,
                DesempenhoGeral = desempenhoGeral
            };

            var predictionEngine = _mlContext.Model.CreatePredictionEngine<FuncionarioDesempenho, ReclamacaoPrediction>(_model);
            var prediction = predictionEngine.Predict(input);

            return prediction.ReclamacoesSoluPrevistas;
        }
    }
}
