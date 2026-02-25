using backend.Data;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Service
{
    public class TurmaService
    {
        private readonly AppDbContext _appContext;

        public TurmaService(AppDbContext appContext)
        {
            _appContext = appContext;
        }

        public Turma cadastrarTurma(string nomeTurma, int qtdAlunos, int qtdCiclos, int mediaTurma, List<Aluno> alunos, List<Ciclo> ciclos)
        {
            try
            {
                var novaTurma = new Turma
                {
                    nomeTurma = nomeTurma,
                    qtdAlunos = qtdAlunos,
                    qtdCiclos = qtdCiclos,
                    mediaTurma = mediaTurma,
                    Alunos = alunos,
                    Ciclos = ciclos,
                };

                _appContext.Turmas.Add(novaTurma);
                _appContext.SaveChanges();
                return novaTurma;
            } catch(DbUpdateException)
            {
                throw new Exception("Erro ao salvar turma no banco de dados");
            }
        }

        public List<Turma> listarTurmas()
        {
            try
            {
                return _appContext.Turmas.ToList();
            } catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro inesperado no servidor.", ex);
            }
        }

        public Turma? listarTurmaId(long turmaId)
        {
            try
            {
                var turma = _appContext.Turmas.Find(turmaId);

                if (turma == null)
                {
                    throw new KeyNotFoundException($"Aluno de RA {turmaId} não encontrado.");
                }

                return turma;
            } catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro inesperado no servidor.", ex);
            }
        }

        public Turma editarTurma(long turmaId, string nomeTurma, int qtdAlunos, int qtdCiclos, int mediaTurma)
        {
            try
            {
                var turma = _appContext.Turmas.Find(turmaId);

                if(turma == null)
                {
                    throw new KeyNotFoundException($"Turma de Id {nomeTurma} não existe");
                }

                turma.nomeTurma = nomeTurma;
                turma.qtdAlunos = qtdAlunos;
                turma.qtdCiclos = qtdCiclos;
                turma.mediaTurma = mediaTurma;

                _appContext.SaveChanges();
                return turma;
            } catch (DbUpdateException)
            {
                throw new Exception("Erro ao salvar a turma no banco de dados");   
            }
        }

        public float mediaFinalTurma(long turmaId)
        {
            var buscaTurma = _appContext.Turmas.Include(t => t.Alunos)
            .FirstOrDefault(at => at.turmaId == turmaId);

            if(buscaTurma == null || !buscaTurma.Alunos.Any())
            {
                return 0;
            }

            var notaFinalTurma = buscaTurma.Alunos.Average(a => a.notaFinal);

            return notaFinalTurma;
        }
    }
}