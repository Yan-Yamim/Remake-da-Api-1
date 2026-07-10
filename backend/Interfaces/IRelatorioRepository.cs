using backend.DTO.DtoRelatorios;
using System.Threading.Tasks;

namespace backend.Interfaces
{
    public interface IRelatorioRepository
    {
        Task<byte[]> GerarRelatorioAlunos(FiltroAlunoReportDTO filtro);
        Task<byte[]> GerarRelatorioCiclos(FiltroCicloReportDTO filtro);
        Task<byte[]> GerarRelatorioTurmas(FiltroTurmaReportDTO filtro);
        Task<byte[]> GerarRelatorioAtividades(FiltroAtividadeReportDTO filtro);
        Task<byte[]> GerarRelatorioGrupos(FiltroGrupoReportDTO filtro);
    }
}