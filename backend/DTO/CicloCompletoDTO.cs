namespace backend.DTO
{
    public class CicloCompletoDTO
    {
        public string nomeCiclo { get; set; }
        public DateOnly dataInicio { get; set; }
        public DateOnly dataFim { get; set; }
        public float pesoNota { get; set; }
        public long turmaId { get; set; }
    }
}