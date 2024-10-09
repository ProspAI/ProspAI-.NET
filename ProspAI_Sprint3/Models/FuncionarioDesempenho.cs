namespace ProspAI_Sprint3.Models;
using Microsoft.ML.Data;
public class FuncionarioDesempenho
{
    [LoadColumn(0)]
    public float FuncionarioId { get; set; }

    [LoadColumn(1)]
    public string Mes { get; set; }

    [LoadColumn(2)]
    public float ReclamacoesResp { get; set; }

    [LoadColumn(3)]
    public float ReclamacoesSolu { get; set; }

    [LoadColumn(4)]
    public float DesempenhoGeral { get; set; }
}
