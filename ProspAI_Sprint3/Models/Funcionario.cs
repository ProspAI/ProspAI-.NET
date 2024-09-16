using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProspAI_Sprint3.Models
{
    [Table("TB_Funcionario_Sprint3")]
    public class Funcionario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id_fun", TypeName = "NUMBER(10)")]
        public int Id_fun { get; set; }

        [Required(ErrorMessage = "O nome do funcionário é obrigatório.")]
        [MaxLength(30)]
        [Column("nm_fun", TypeName = "varchar2(30)")]
        public string Nome_fun { get; set; }

        [Required(ErrorMessage = "O email do funcionário é obrigatório.")]
        [MaxLength(50)]
        [Column("ds_email", TypeName = "varchar2(50)")]
        public string Email_fun { get; set; }

        [Required(ErrorMessage = "A senha do funcionário é obrigatória.")]
        [MaxLength(100)]
        [Column("ds_senha", TypeName = "varchar2(100)")]
        public string Senha_fun { get; set; }

        [Required]
        [Column("dt_adm", TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime Data_admissao { get; set; }

        [JsonIgnore] // Evita referência cíclica durante a serialização
        public ICollection<Desempenho> Desempenhos { get; set; } = new List<Desempenho>();

        [JsonIgnore] // Evita referência cíclica durante a serialização
        public ICollection<Reclamacao> Reclamacoes { get; set; } = new List<Reclamacao>();
    }
}