using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaEscola.Aplicacao.Professores.Servicos.Interface;
using SistemaEscola.DataTransfer.Professores;
using SistemaEscola.Dominio.Professores.Entidade;

namespace SistemaEscola.API.Controllers.Professores
{
    [ApiController]
    [Route("[controller]")]
    public class ProfessorController : ControllerBase
    {
        readonly private IProfessorAppServico professorAppServico;
        public ProfessorController(IProfessorAppServico professorAppServico) {
            this.professorAppServico = professorAppServico;
        }

        [HttpPost] 
        [Route("Adicionar")]
        public async Task<ActionResult<Professor>> Adicionar(ProfessorRequest request)
        {
            var resultado = await professorAppServico.Adicionar(request);

            return Ok(resultado);
        }
        [HttpGet]
        [Route("Listar")]
        public async Task<ActionResult<Professor>> Listar() 
        {
            var resultado = await professorAppServico.ListarProfessor();

            return Ok(resultado);
        }

    }

}
  