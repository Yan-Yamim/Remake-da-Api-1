namespace backend.DTO
{
    public class AlunoDTO
    {
        public string NomeAluno { get; set; }
        public string Email { get; set; }
        public int Idade { get; set; }
        public int Ra { get; set; }
        public float notaFinal { get; set; }
        public List<TurmaDTO> Turmas { get; set; } = new();
    }
}