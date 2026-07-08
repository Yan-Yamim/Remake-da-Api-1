using csvHelper;

namespace backend.Service
{
    public class RelatorioService : RelatorioRepository
    {
        private readonly AppDbContext _appContext;

        public RelatorioService(AppDbContext appContext) => _appContext = appContext;

        public byte[] GerarRelatorioAlunos(FiltroAlunoReportDTO filtro)
        {
            var dados = _appContext.Alunos
                .Where(a => !filtro.TurmaId.HasValue || a.TurmaId == filtro.TurmaId)
                .Select(a => new LinhaRelatorioAlunoDTO
                {
                    NomeAluno = a.nomeAluno,
                    NomeTurma = a.Turma.nomeTurma,
                    NomeCiclo = a.Ciclo.nomeCiclo,
                    NomeGrupo = a.Grupo.nomeGrupo,
                    NotaFinal = a.notaFinal.ToString()
                }).toList();

                return CSVHelper.GerarCSV(dados);

        public byte[] GerarRelatorioCiclos(FiltroCicloReportDTO filtro)
        {
            var dados = _appContext.Ciclos
                .Where(c => !filtro.TurmaId.HasValue || c.TurmaId == filtro.TurmaId)
                .Select(c => new LinhaRelatorioCicloDTO
                {
                    NomeCiclo = c.nomeCiclo,
                    NomeTurma = c.Turma.nomeTurma,
                    NomeGrupo = c.Grupo.nomeGrupo,
                    PesoNota = c.pesoNota.ToString(),
                    MediaCiclo = c.mediaCiclo.ToString()
                }).toList();

                return CSVHelper.GerarCSV(dados);
        }

        public byte[] GerarRelatorioTurmas(FiltroTurmaReportDTO filtro)
        {
            var dados = _appContext.Turmas
                .Where(t => !filtro.CicloId.HasValue || t.CicloId == filtro.CicloId)
                .Select(t => new LinhaRelatorioTurmaDTO
                {
                    NomeTurma = t.nomeTurma,
                    NomeCiclo = t.Ciclo.nomeCiclo,
                    NomeGrupo = t.Grupo.nomeGrupo,
                    QtdAluno = t.Alunos.Count(),
                    MediaTurma = t.mediaTurma.ToString()
                }).toList();

                return CSVHelper.GerarCSV(dados);
        }

        public byte[] GerarRelatorioAtividades(FiltroAtividadeReportDTO filtro)
        {
            var dados = _appContext.Atividades
                .Where(a => !filtro.CicloId.HasValue || a.CicloId == filtro.CicloId)
                .Select(a => new LinhaRelatorioAtividadeDTO
                {
                    NomeAtividade = a.nomeAtividade,
                    NomeCiclo = a.Ciclo.nomeCiclo,
                    MediaAtividade = a.mediaAtividade.ToString()
                }).toList();

                return CSVHelper.GerarCSV(dados);
        }

        public byte[] GerarRelatorioGrupos(FiltroGrupoReportDTO filtro)
        {
            var dados = _appContext.Grupos
                .Where(g => !filtro.CicloId.HasValue || g.CicloId == filtro.CicloId)
                .Select(g => new LinhaRelatorioGrupoDTO
                {
                    NomeGrupo = g.nomeGrupo,
                    NomeCiclo = g.Ciclo.nomeCiclo,
                    QtdAluno = g.Alunos.Count(),
                    MediaGrupo = g.mediaGrupo.ToString()
                }).toList();

                return CSVHelper.GerarCSV(dados);
        }
    }
}