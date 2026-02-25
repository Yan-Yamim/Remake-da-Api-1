using backend.Models;
using backend.Service;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrupoController : ControllerBase
    {
        private readonly GrupoService _grupoService;

        public GrupoController(GrupoService grupoService)
        {
            _grupoService = grupoService;
        }

        [HttpGet]
        public ActionResult<Grupo> GetGrupo()
        {
            var grupos = _grupoService.listarGrupos;
            return Ok(grupos);
        }

        [HttpGet("{id}")]
        public ActionResult<Grupo> GetGrupoId(long grupoId)
        {
            var grupoComId = _grupoService.listarGrupoId(grupoId);
            return Ok(grupoComId);
        }

        [HttpPost]
        public ActionResult<Grupo> PostGrupo([FromBody] Grupo grupo)
        {
            var grupoSalvo =_grupoService.cadastrarGrupo(
                grupo.nomeGrupo,
                new List<Aluno>()
            );

            return CreatedAtAction(nameof(GetGrupoId), new { id = grupoSalvo.grupoId }, grupoSalvo);
        }

        [HttpPut("{id}")]
        public ActionResult<Grupo> PutGrupo(long grupoId, [FromBody] Grupo grupo)
        {
            var grupoEditado = _grupoService.editarGrupo(
                grupoId,
                grupo.nomeGrupo,
                grupo.Alunos
            );

            return Ok(grupoEditado);
        }
    }
}