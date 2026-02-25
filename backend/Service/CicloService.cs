using backend.Data;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Service
{
    public class CicloService
    {
        private readonly AppDbContext _appContext;

        public CicloService(AppDbContext appContext)
        {
            _appContext = appContext;
        }

        public Ciclo cadastrarCiclo(string nomeCiclo, DateOnly dataInicio, DateOnly dataFim, float pesoNota, Turma turma, List<Atividade> atividades)
        {
            try
            {
                var novoCiclo = new Ciclo
                {
                    nomeCiclo = nomeCiclo,
                    dataInicio = dataInicio,
                    dataFim = dataFim,
                    pesoNota = pesoNota,
                    Turma = turma,
                    Atividades = atividades
                };

                _appContext.Ciclos.Add(novoCiclo);
                _appContext.SaveChanges();
                return novoCiclo;
            } catch(DbUpdateException)
            {
                throw new Exception("Erro ao salvar ciclo no banco de dados");
            }
        }

        public List<Ciclo> listarCiclo()
        {
            try
            {
                return _appContext.Ciclos.ToList();
            } catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro inesperado no servidor.", ex);
            }
        }

        public Ciclo? listarCicloId(long idCiclo)
        {
            try
            {
                var ciclo = _appContext.Ciclos.Find(idCiclo);

                if (ciclo == null)
                {
                    throw new KeyNotFoundException($"Aluno de RA {idCiclo} não encontrado.");
                }

                return ciclo;
            } catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro inesperado no servidor.", ex);
            }
        }

        public Ciclo editarCiclo(long idCiclo, string nomeCiclo, DateOnly dataInicio, DateOnly dataFim, float pesoNota)
        {
            try
            {
                var ciclo = _appContext.Ciclos.Find(idCiclo);

                if(ciclo == null)
                {
                    throw new KeyNotFoundException($"Aluno de Id {nomeCiclo} não existe");
                }

                ciclo.nomeCiclo = nomeCiclo;
                ciclo.dataInicio = dataInicio;
                ciclo.dataFim = dataFim;
                ciclo.pesoNota = pesoNota;

                _appContext.SaveChanges();
                return ciclo;
            } catch (DbUpdateException)
            {
                throw new Exception("Erro ao salvar a turma no banco de dados");   
            }
        }
    }
}