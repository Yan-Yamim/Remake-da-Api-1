using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using backend.Service;
using backend.Interfaces;
using backend.DTO.DtoRelatorios;

namespace backend.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class RelatorioController : ControllerBase
    {
        private readonly IRelatorioRepository _relatorioService;

        public RelatorioController(IRelatorioRepository relatorioService)
        {
            _relatorioService = relatorioService;
        }

        [HttpGet("aluno")]
        public async Task<IActionResult> GetRelatorioAluno([FromQuery] FiltroAlunoReportDTO filtro)
        {
            byte[] fileBytes = await _relatorioService.GerarRelatorioAlunos(filtro);

            if (fileBytes == null || fileBytes.Length == 0)
            {
                return NotFound("Nenhum dado encontrado para gerar o relatório.");
            }

            string nomeArquivo = "relatorio_alunos.csv";
            return File(fileBytes, "text/csv", nomeArquivo);
        }
    }
}