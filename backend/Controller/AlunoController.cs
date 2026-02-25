using backend.Models;
using backend.Service;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly AlunoService _alunoService;

        public AlunoController(AlunoService alunoService)
        {
            _alunoService = alunoService;   
        }

        [HttpGet]
        public ActionResult<List<Aluno>> GetAlunos()
        {
            var alunos = _alunoService.listarAlunos();
            return Ok(alunos);
        }

        [HttpGet("{ra}")]
        public ActionResult<Aluno> GetAlunoRa(int ra)
        {
            var alunoRa = _alunoService.listarAlunoRa(ra);
            return Ok(alunoRa);
        }

        [HttpPost]
        public ActionResult<Aluno> PostAluno([FromBody] Aluno aluno)
        {
            var alunoSalvo = _alunoService.cadastrarAluno(
                aluno.nomeAluno,
                aluno.sobrenome,
                aluno.idade,
                aluno.ra,
                aluno.email,
                aluno.notaFinal,
                new List<Ciclo>(),
                new List<Turma>(),
                new List<Atividade>()
            );

            return CreatedAtAction(nameof(GetAlunoRa), new{ ra = alunoSalvo.ra }, alunoSalvo);
        }

        [HttpPut("{id}")]
        public ActionResult<Aluno> PutAluno(long alunoId, [FromBody] Aluno aluno)
        {
            var alunoEditado = _alunoService.editarAluno(
                alunoId,
                aluno.nomeAluno,
                aluno.sobrenome,
                aluno.idade,
                aluno.ra,
                aluno.email,
                aluno.notaFinal
            );

            return Ok(alunoEditado);
        }
    }
}