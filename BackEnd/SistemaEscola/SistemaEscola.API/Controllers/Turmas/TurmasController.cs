using Microsoft.AspNetCore.Mvc;
using SistemaEscola.Aplicacao.Turmas.Servicos.Interface;
using SistemaEscola.DataTransfer.Turmas;
using SistemaEscola.Dominio.Turmas.Entidade;

namespace SistemaEscola.API.Controllers.Turmas
{
    [ApiController]
    [Route("[controller]")]
    public class TurmasController : ControllerBase
    {
        private readonly ITurmaAppServico turmaAppServico;
        public TurmasController(ITurmaAppServico turmaAppServico)
        {
            this.turmaAppServico = turmaAppServico;
        }

        [HttpPost]
        [Route("Adicionar")]
        public async Task<IActionResult> Adicionar(string nome,  int[] idAlunos)
        {
            var resultado = await turmaAppServico.Adicionar(nome, idAlunos);

            return Ok(resultado);
        }
        [HttpPut]
        [Route("Atualizar")]
        public async Task<ActionResult<Turma>> Atualizar(TurmaResquet reque)
        {
            return Ok();
        }


        [HttpGet]
        [Route("Listar")]
        public async Task<ActionResult<List<Turma>>> Listar()
        {
            var resultado = await turmaAppServico.Listar();

            return resultado;
        }

        [HttpGet]
        [Route("Recuperar")]
        public async Task<ActionResult<Turma>> Recuperar(int id)
        {
            var resultado = await turmaAppServico.Recuperar(id);

            return resultado;
        }
 
    }
}
