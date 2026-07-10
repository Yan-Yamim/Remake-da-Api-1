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
        private readonly TurmaService _turmaService;

        public CicloController(CicloService cicloService, TurmaService turmaService)
        {
            _cicloService = cicloService;
            _turmaService = turmaService;
        }

        [HttpGet]
        public ActionResult<List<Ciclo>> GetCiclo() 
        {
            var ciclos = _cicloService.listarCiclo();
            return Ok(ciclos);
        }

        [HttpGet("{id}")]
        public ActionResult<Ciclo> GetCicloId(long id)
        {
            var cicloComId = _cicloService.listarCicloId(id);
            if (cicloComId == null) return NotFound("Ciclo não encontrado.");
            return Ok(cicloComId);
        }

        [HttpPost]
        public ActionResult<Ciclo> PostCiclo([FromBody] Ciclo ciclo)
        {
            var turma = _turmaService.listarTurmaId(ciclo.turmaId);

            if (turma == null)
            {
                return NotFound($"Turma com ID {ciclo.turmaId} não encontrada.");
            }

            var cicloSalvo = _cicloService.cadastrarCiclo(
                ciclo.nomeCiclo,
                ciclo.dataInicio,
                ciclo.dataFim,
                ciclo.pesoNota,
                turma,
                new List<Atividade>()
            );

            return CreatedAtAction(nameof(GetCicloId), new { id = cicloSalvo.idCiclo }, cicloSalvo);
        }

        [HttpPut("{id}")]
        public ActionResult<Ciclo> PutCiclo(long id, [FromBody] Ciclo ciclo)
        {
            var cicloEditado = _cicloService.editarCiclo(
                id,
                ciclo.nomeCiclo,
                ciclo.dataInicio,
                ciclo.dataFim,
                ciclo.pesoNota
            );

            return Ok(cicloEditado);
        }
    }
}