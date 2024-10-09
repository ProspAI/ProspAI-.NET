using Microsoft.ML.Data;

namespace ProspAI_Sprint3.Models
{
    public class ReclamacaoPrediction
    {
        [ColumnName("Score")]
        public float ReclamacoesSoluPrevistas { get; set; }
    }
}
