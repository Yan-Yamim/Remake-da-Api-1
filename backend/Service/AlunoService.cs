using backend.Data;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Service
{
    public class AlunoService
    {
        private readonly AppDbContext _appContext;

        public AlunoService(AppDbContext appContext)
        {
            _appContext = appContext;
        }

        public Aluno cadastrarAluno(string nomeAluno, string sobrenome, int idade, int ra, string email, float notaFinal, 
                                    List<Ciclo> ciclos, List<Turma> turmas, List<Atividade> atividades)
        {
            try
            {
                var novoAluno = new Aluno
                {
                    nomeAluno = nomeAluno,
                    sobrenome = sobrenome,
                    idade = idade,
                    ra = ra,
                    email = email,
                    notaFinal = notaFinal,
                    Ciclos = ciclos,
                    Turmas = turmas,
                    Atividades = atividades
                };

                _appContext.Alunos.Add(novoAluno);
                _appContext.SaveChanges();
                return novoAluno;
            } catch(DbUpdateException)
            {
                throw new Exception("Erro ao salvar aluno no banco de dados");
            }
        }

        public List<Aluno> listarAlunos()
        {
            try
            {
                return _appContext.Alunos.ToList();
            } catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro inesperado no servidor.", ex);
            }
        }

        public Aluno? listarAlunoRa(int ra)
        {
            try
            {
                var aluno = _appContext.Alunos.Find(ra);

                if (aluno == null)
                {
                    throw new KeyNotFoundException($"Aluno de RA {ra} não encontrado.");
                }

                return aluno;
            } catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro inesperado no servidor.", ex);
            }
        }

        public Aluno editarAluno(long alunoId, string nomeAluno, string sobrenome, int idade, int ra, string email, float notaFinal)
        {
            try
            {
                var aluno = _appContext.Alunos.Find(alunoId);

                if(aluno == null)
                {
                    throw new KeyNotFoundException($"Aluno de Id {nomeAluno} não existe");
                }

                aluno.nomeAluno = nomeAluno;
                aluno.sobrenome = sobrenome;
                aluno.idade = idade;
                aluno.ra = ra;
                aluno.email = email;
                aluno.notaFinal = notaFinal;

                _appContext.SaveChanges();
                return aluno;
            } catch (DbUpdateException)
            {
                throw new Exception("Erro ao salvar a região no banco de dados");   
            }
        }

        public float MediaFinalAluno(long alunoId)
        {
            var buscaAluno = _appContext.Alunos.Include(a => a.Atividades)
            .ThenInclude(at => at.Ciclo).FirstOrDefault(a => a.alunoId == alunoId); 

            if(buscaAluno == null || !buscaAluno.Atividades.Any())
            {
                return 0;
            }

            var notaFinal = buscaAluno.Atividades.GroupBy(a => a.cicloId).Select(grupo => new
            {
               mediaDasAtividades = grupo.Average(a => a.notaAtividade),
               pesoCiclo = grupo.First().Ciclo.pesoNota 
            }).Sum(resultado => resultado.mediaDasAtividades * resultado.pesoCiclo);

            return notaFinal;
        }
    }
}