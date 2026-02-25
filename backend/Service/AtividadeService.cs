using backend.Data;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Service
{
    public class AtividadeService
    {
        private readonly AppDbContext _appContext;

        public AtividadeService(AppDbContext appContext)
        {
            _appContext = appContext;
        }

        public Atividade cadastrarAtividade(string nomeAtividade, float notaAtividade, Aluno aluno, Ciclo ciclo)
        {
            try
            {
                var novaAtividade = new Atividade
                {
                    nomeAtividade = nomeAtividade,
                    notaAtividade = notaAtividade,
                    Aluno = aluno,
                    Ciclo = ciclo,
                };

                _appContext.Atividades.Add(novaAtividade);
                _appContext.SaveChanges();
                return novaAtividade;
            } catch(DbUpdateException)
            {
                throw new Exception("Erro ao salvar atividade no banco de dados");
            }
        }

        public List<Atividade> listarAtividades()
        {
            try
            {
                return _appContext.Atividades.ToList();
            } catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro inesperado no servidor.", ex);
            }
        }

        public Atividade? listarAtividadeId(long ativId)
        {
            try
            {
                var atividade = _appContext.Atividades.Find(ativId);

                if (atividade == null)
                {
                    throw new KeyNotFoundException($"Atividade de ID {ativId} não encontrado.");
                }

                return atividade;
            } catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro inesperado no servidor.", ex);
            }
        }

        public Atividade editarAtividade(long ativId, string nomeAtividade, float notaAtividade, Aluno aluno, Ciclo ciclo)
        {
            try
            {
                var atividade = _appContext.Atividades.Find(ativId);

                if(atividade == null)
                {
                    throw new KeyNotFoundException($"Turma de Id {nomeAtividade} não existe");
                }

                atividade.nomeAtividade = nomeAtividade;
                atividade.notaAtividade = notaAtividade;
                atividade.Aluno = aluno;
                atividade.Ciclo = ciclo;

                _appContext.SaveChanges();
                return atividade;
            } catch (DbUpdateException)
            {
                throw new Exception("Erro ao salvar a turma no banco de dados");   
            }
        }
    }
}