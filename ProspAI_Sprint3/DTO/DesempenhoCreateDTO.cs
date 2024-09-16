namespace ProspAI_Sprint3.DTO
{
    public class DesempenhoCreateDTO
    {
        public string Mes_desem { get; set; }
        public int Reclamacoes_resp { get; set; }
        public int Reclamacoes_solu { get; set; }
        public int Id_fun { get; set; } // Id do Funcionario para associação
    }
}