using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProspAI_Sprint3.Models
{
    [Table("TB_Desempenho_Sprint3")]
    public class Desempenho
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id_desem", TypeName = "NUMBER(10)")]
        public int Id_desem { get; set; }

        [Required]
        [MaxLength(15)]
        [Column("ds_mes", TypeName = "varchar2(15)")]
        public string Mes_desem { get; set; }

        [Required]
        [Column("nr_reclama", TypeName = "number(3)")]
        public int Reclamacoes_resp { get; set; }

        [Required]
        [Column("nr_reclama_solu", TypeName = "number(3)")]
        public int Reclamacoes_solu { get; set; }

        [ForeignKey("Funcionario")]
        [Column("Id_fun", TypeName = "NUMBER(10)")]
        public int Id_fun { get; set; }

        [JsonIgnore] // Evita referência cíclica durante a serialização
        public Funcionario Funcionario { get; set; }
    }
}