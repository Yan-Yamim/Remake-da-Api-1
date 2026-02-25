using backend.Data;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Service
{
    public class GrupoService
    {
        private readonly AppDbContext _appContext;

        public GrupoService(AppDbContext appContext)
        {
            _appContext = appContext;
        }

        public Grupo cadastrarGrupo(string nomeGrupo, List<Aluno> alunos)
        {
            try
            {
                var novoGrupo = new Grupo
                {
                    nomeGrupo = nomeGrupo,
                    Alunos = alunos,
                };

                _appContext.Grupos.Add(novoGrupo);
                _appContext.SaveChanges();
                return novoGrupo;
            } catch(DbUpdateException)
            {
                throw new Exception("Erro ao salvar turma no banco de dados");
            }
        }

        public List<Grupo> listarGrupos()
        {
            try
            {
                return _appContext.Grupos.ToList();
            } catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro inesperado no servidor.", ex);
            }
        }

        public Grupo? listarGrupoId(long grupoId)
        {
            try
            {
                var grupo = _appContext.Grupos.Find(grupoId);

                if (grupo == null)
                {
                    throw new KeyNotFoundException($"Aluno de RA {grupoId} não encontrado.");
                }

                return grupo;
            } catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro inesperado no servidor.", ex);
            }
        }

        public Grupo editarGrupo(long grupoId, string nomeGrupo, List<Aluno> alunos)
        {
            try
            {
                var grupo = _appContext.Grupos.Find(grupoId);

                if(grupo == null)
                {
                    throw new KeyNotFoundException($"Turma de Id {nomeGrupo} não existe");
                }

                grupo.nomeGrupo = nomeGrupo;
                grupo.Alunos = alunos;

                _appContext.SaveChanges();
                return grupo;
            } catch (DbUpdateException)
            {
                throw new Exception("Erro ao salvar a turma no banco de dados");   
            }
        }
    }
}