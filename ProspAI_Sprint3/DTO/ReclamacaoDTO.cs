using System;
using System.ComponentModel.DataAnnotations;

namespace ProspAI_Sprint3.Models.DTOs
{
    public class ReclamacaoDTO
    {
        public int Id_recla { get; set; }

        [MaxLength(30)]
        [Required(ErrorMessage = "O nome é obrigatório!")]
        public string Nm_clie { get; set; }

        [Required(ErrorMessage = "A data é obrigatória!")]
        [DataType(DataType.Date)]
        public DateTime Dt_recla { get; set; }

        [MaxLength(20)]
        [Required(ErrorMessage = "A origem da reclamação é obrigatória!")]
        public string Origem_recla { get; set; }

        [MaxLength(1)]
        [Required(ErrorMessage = "O status da solução da reclamação é obrigatório!")]
        public string Solucionada_recla { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage = "O assunto da reclamação é obrigatório!")]
        public string Assunto_recla { get; set; }

        [Required(ErrorMessage = "O ID do funcionário é obrigatório!")]
        public int Id_fun { get; set; }
    }
}