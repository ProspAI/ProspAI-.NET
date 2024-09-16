using System;
using System.ComponentModel.DataAnnotations;

namespace ProspAI_Sprint3.Models.DTOs
{
    public class FuncionarioDTO
    {
        public int Id_fun { get; set; }

        [Required(ErrorMessage = "O nome do funcionário é obrigatório.")]
        [MaxLength(30)]
        public string Nome_fun { get; set; }

        [Required(ErrorMessage = "O email do funcionário é obrigatório.")]
        [MaxLength(50)]
        public string Email_fun { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Data_admissao { get; set; }
    }
}