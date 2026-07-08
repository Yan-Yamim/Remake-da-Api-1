using backend.DTO.DtoRelatorios;

namespace backend.Service
{
    public interface IRelatorioRepository
    {
        byte[] GerarRelatorioAlunos(FiltroAlunoReportDTO filtro);
        byte[] GerarRelatorioCiclos(FiltroCicloReportDTO filtro);
        byte[] GerarRelatorioTurmas(FiltroTurmaReportDTO filtro);
        byte[] GerarRelatorioAtividades(FiltroAtividadeReportDTO filtro);
        byte[] GerarRelatorioGrupos(FiltroGrupoReportDTO filtro);
    }
}