namespace backend.DTO
{
    public class AlunoDTO
    {
        public string NomeAluno { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public int Idade { get; set; }
        public int Ra { get; set; }
        public float notaFinal { get; set; }
        public List<CicloDTO> Ciclos { get; set; } = new();
        public List<TurmaDTO> Turmas { get; set; } = new();
        public List<AtividadeDTO> Atividades { get; set; } = new();
    }
}