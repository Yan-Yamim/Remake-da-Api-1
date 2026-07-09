namespace backend.DTO.DtoRelatorios
{
    public class LinhaRelatorioGrupoDTO
    {
        public string NomeGrupo { get; set; }
        public string NomeTurma { get; set; }
        public string NomeCiclo { get; set; }
        public string NomeAluno { get; set; }
        public int QtdAluno { get; set; }
        public decimal MediaGrupo { get; set; }
    }
}