using backend.Models;
using backend.Service;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmaController : ControllerBase
    {
        private readonly TurmaService _turmaService;

        public TurmaController(TurmaService turmaService)
        {
            _turmaService = turmaService;
        }

        [HttpGet]
        public ActionResult<Turma> GetTurma()
        {
            var alunos = _turmaService.listarTurmas();
            return Ok(alunos);
        }

        [HttpGet("{id}")]
        public ActionResult<Turma> GetTurmaId(long turmaId)
        {
            var turmaComId = _turmaService.listarTurmaId(turmaId);
            return Ok(turmaComId);
        }

        [HttpPost]
        public ActionResult<Turma> PostTurma([FromBody] Turma turma)
        {
            var turmaSalva = _turmaService.cadastrarTurma(
                turma.nomeTurma,
                turma.qtdAlunos,
                turma.qtdCiclos,
                turma.mediaTurma,
                new List<Aluno>(),
                new List<Ciclo>()
            );

            return CreatedAtAction(nameof(GetTurmaId), new { id = turmaSalva.turmaId }, turmaSalva);
        }

        [HttpPut("{id}")]
        public ActionResult<Turma> PutTurma(long turmaId, [FromBody] Turma turma)
        {
            var turmaEditada = _turmaService.editarTurma(
                turmaId,
                turma.nomeTurma,
                turma.qtdAlunos,
                turma.qtdCiclos,
                turma.mediaTurma
            );

            return Ok(turmaEditada);
        }
    }
}