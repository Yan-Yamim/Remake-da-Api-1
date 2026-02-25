using backend.Models;
using backend.Service;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CicloController : ControllerBase
    {
        private readonly CicloService _cicloService;

        public CicloController(CicloService cicloService)
        {
            _cicloService = cicloService;
        }

        [HttpGet]
        public ActionResult<Ciclo> GetCiclo()
        {
            var ciclos = _cicloService.listarCiclo();
            return Ok(ciclos);
        }

        [HttpGet("{id}")]
        public ActionResult<Ciclo> GetCicloId(long idCiclo)
        {
            var cicloComId = _cicloService.listarCicloId(idCiclo);
            return Ok(cicloComId);
        }

        [HttpPost]
        public ActionResult<Ciclo> PostCiclo([FromBody] Ciclo ciclo)
        {
            var cicloSalvo = _cicloService.cadastrarCiclo(
                ciclo.nomeCiclo,
                ciclo.dataInicio,
                ciclo.dataFim,
                ciclo.pesoNota,
                ciclo.Turma,
                new List<Atividade>()
            );

            return CreatedAtAction(nameof(GetCicloId), new { id = cicloSalvo.idCiclo }, cicloSalvo);
        }

        [HttpPut("{id}")]
        public ActionResult<Turma> PutCiclo(long idCiclo, [FromBody] Ciclo ciclo)
        {
            var cicloEditado = _cicloService.editarCiclo(
                idCiclo,
                ciclo.nomeCiclo,
                ciclo.dataInicio,
                ciclo.dataFim,
                ciclo.pesoNota
            );

            return Ok(cicloEditado);
        }
    }
}