namespace backend.DTO
{
    public class TurmaAlunosDTO
    {
        public string NomeTurma { get; set; }
        public int QtdAlunos { get; set; }
        public List<AlunoDTO> Alunos { get; set; } = new();
    }
}