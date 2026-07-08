namespace backend.DTO
{
    public class TurmaDTO
    {
        public string NomeTurma { get; set; }
        public int QtdAlunos { get; set; }
        public int QtdCiclos { get; set; }
        public int MediaTurma { get; set; }
        public List<AlunoDTO> Alunos { get; set; } = new();
        public List<CicloDTO> Ciclos { get; set; } = new();
    }
}