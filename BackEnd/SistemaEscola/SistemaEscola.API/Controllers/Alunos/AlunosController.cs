using Microsoft.AspNetCore.Mvc;
using SistemaEscola.Aplicacao.Alunos.Servicos.Interface;

namespace SistemaEscola.API.Controllers.NovaPasta
{
    [ApiController]
    [Route("[controller]")]
    public class AlunosController : ControllerBase
    {
        private readonly IAlunoAppServico alunoAppServico;

        public AlunosController(IAlunoAppServico alunoAppServico)
        {
            this.alunoAppServico = alunoAppServico;
        }

        [HttpPost]
        [Route("Adicionar")]
        public async Task<IActionResult> Adicionar(string nome)
        {
            var resultado = await alunoAppServico.Adicionar(nome);

            return Ok(resultado);
        }

        [HttpGet]
        [Route("ListarAlunos")]
        public async Task<IActionResult> ListarAluno()
        {
            var resultado = await alunoAppServico.ListarAlunos();

            return Ok(resultado);
        }
        [HttpGet]
        [Route("Recuperar")]
        public async Task<IActionResult> RecupearAluno(int id)
        {
            var resultado = await alunoAppServico.RecupearAlunoPorId(id);

            return Ok(resultado);
        }

        [HttpDelete]
        [Route("Deletar")]
        public async Task<IActionResult> Delete(int id)
        {
            await alunoAppServico.Deletar(id);

            return Ok();
        }
    }
}
