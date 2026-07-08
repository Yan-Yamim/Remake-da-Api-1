namespace backend.DTO.DtoRelatorios
{
    public class FiltroGrupoReportDTO
    {
        public string NomeGrupo { get; set; }
        public string NomeTurma { get; set; }
        public string NomeCiclo { get; set; }
        public int QtdAluno { get; set; }
        public decimal MediaGrupo { get; set; }
    }
}