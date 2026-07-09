using Microsoft.EntityFrameworkCore;
using backend.Data;
using backend.Service.Interfaces;
using backend.DTO.DtoRelatorios;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Service
{
    public class RelatorioService : IRelatorioRepository
    {
        private readonly AppDbContext _appContext;
        private readonly ICsvExportService _csvExportService;

        public RelatorioService(AppDbContext appContext, ICsvExportService csvExportService)
        {
            _appContext = appContext;
            _csvExportService = csvExportService;
        }

        public async Task<byte[]> GerarRelatorioAlunos(FiltroAlunoReportDTO filtro)
        {
            var query = _appContext.Turmas
                .AsNoTracking()
                .Where(t => !filtro.TurmaId.HasValue || t.turmaId == filtro.TurmaId.Value)
                .SelectMany(t => t.Alunos.Select(a => new LinhaRelatorioAlunoDTO
                {
                    NomeAluno = a.nomeAluno,
                    NomeTurma = t.nomeTurma,
                    NomeCiclo = a.Ciclos.Select(c => c.nomeCiclo).FirstOrDefault() ?? "Sem Ciclo",
                    NomeGrupo = a.Grupos.Select(g => g.nomeGrupo).FirstOrDefault() ?? "Sem Grupo",
                    NotaFinal = a.notaFinal.ToString()
                }));

            var dados = await query.ToListAsync();
            return _csvExportService.ExportToCsv(dados);
        }

        public async Task<byte[]> GerarRelatorioCiclos(FiltroCicloReportDTO filtro)
        {
            var query = _appContext.Ciclos
                .AsNoTracking()
                .Where(c => !filtro.TurmaId.HasValue || c.turmaId == filtro.TurmaId.Value)
                .Select(c => new LinhaRelatorioCicloDTO
                {
                    NomeCiclo = c.nomeCiclo,
                    NomeTurma = c.Turma.nomeTurma
                });

            var dados = await query.ToListAsync();
            return _csvExportService.ExportToCsv(dados);
        }

        public async Task<byte[]> GerarRelatorioTurmas(FiltroTurmaReportDTO filtro)
        {
            var query = _appContext.Ciclos
                .AsNoTracking()
                .Where(c => !filtro.CicloId.HasValue || c.idCiclo == filtro.CicloId.Value)
                .Select(c => new LinhaRelatorioTurmaDTO
                {
                    NomeTurma = c.Turma.nomeTurma,
                    NomeCiclo = c.nomeCiclo
                });

            var dados = await query.ToListAsync();
            return _csvExportService.ExportToCsv(dados);
        }

        public async Task<byte[]> GerarRelatorioAtividades(FiltroAtividadeReportDTO filtro)
        {
            var query = _appContext.Ciclos
                .AsNoTracking()
                .Where(c => !filtro.CicloId.HasValue || c.idCiclo == filtro.CicloId.Value) 
                .SelectMany(c => c.Atividades.Select(act => new LinhaRelatorioAtividadeDTO
                {
                    NomeAtividade = act.nomeAtividade,
                    NomeCiclo = c.nomeCiclo
                }));

            var dados = await query.ToListAsync();
            return _csvExportService.ExportToCsv(dados);
        }

        public async Task<byte[]> GerarRelatorioGrupos(FiltroGrupoReportDTO filtro)
        {
            var query = _appContext.Alunos
                .AsNoTracking()
                .Where(a => a.Ciclos.Any(c => !filtro.CicloId.HasValue || c.idCiclo == filtro.CicloId.Value)) 
                .SelectMany(a => a.Grupos.Select(g => new LinhaRelatorioGrupoDTO
                {
                    NomeGrupo = g.nomeGrupo,
                    NomeCiclo = a.Ciclos.Select(c => c.nomeCiclo).FirstOrDefault() ?? "Sem Ciclo",
                    NomeAluno = a.nomeAluno
                }));

            var dados = await query.ToListAsync();
            return _csvExportService.ExportToCsv(dados);
        }
    }
}