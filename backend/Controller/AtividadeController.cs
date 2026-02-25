using backend.Models;
using backend.Service;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtividadeController : ControllerBase
    {
        private readonly AtividadeService _atividadeService;

        public AtividadeController(AtividadeService atividadeService)
        {
            _atividadeService = atividadeService;
        }

        [HttpGet]
        public ActionResult<Atividade> GetAtividade()
        {
            var atividades = _atividadeService.listarAtividades;
            return Ok(atividades);
        }

        [HttpGet("{id}")]
        public ActionResult<Atividade> GetAtividadeId(long ativId)
        {
            var atividadeComId = _atividadeService.listarAtividadeId(ativId);
            return Ok(atividadeComId);
        }

        [HttpPost]
        public ActionResult<Atividade> PostAtividade([FromBody] Atividade atividade)
        {
            var atividadeSalvo =_atividadeService.cadastrarAtividade(
                atividade.nomeAtividade,
                atividade.notaAtividade,
                atividade.Aluno,
                atividade.Ciclo
            );

            return CreatedAtAction(nameof(GetAtividadeId), new { id = atividadeSalvo.ativId }, atividadeSalvo);
        }

        [HttpPut("{id}")]
        public ActionResult<Atividade> PutAtividade(long ativId, [FromBody] Atividade atividade)
        {
            var atividadeEditado = _atividadeService.editarAtividade(
                ativId,
                atividade.nomeAtividade,
                atividade.notaAtividade,
                atividade.Aluno,
                atividade.Ciclo
            );

            return Ok(atividadeEditado);
        }
    }
}