using SistemaEscola.Aplicacao.Professores.Servicos.Interface;
using SistemaEscola.DataTransfer.Professores;
using SistemaEscola.Dominio.Professores.Entidade;
using SistemaEscola.Dominio.Professores.Servicos.Interface;
using SistemaEscola.Dominio.Repositorio.Interface;
using SistemaEscola.Dominio.Turmas.Entidade;
using SistemaEscola.Dominio.Turmas.Servicos.Interface;
using SistemaEscola.Dominio.Usuarios.Entidade;
using SistemaEscola.Dominio.Usuarios.Enum;
using SistemaEscola.Dominio.Usuarios.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscola.Aplicacao.Professores.Servicos
{
    public class ProfessorAppServico : IProfessorAppServico
    {
        private readonly IUsuarioServico usuarioServico;
        private readonly IProfessorServico professorServico;
        private readonly IRepositorioGenerico<Professor> repositorioGenerico;
        private readonly ITurmaServico turmaServico;

        public ProfessorAppServico(IUsuarioServico usuarioServico, IProfessorServico professorServico, IRepositorioGenerico<Professor> repositorioGenerico, ITurmaServico turmaServico = null)
        {
            this.usuarioServico = usuarioServico;
            this.professorServico = professorServico;
            this.repositorioGenerico = repositorioGenerico;
            this.turmaServico = turmaServico;
        }

        public async Task<Professor> Adicionar(ProfessorRequest request)
        {

            Turma turma = await turmaServico.Validar(request.idTurma);

            Professor professor = await professorServico.Instanciar(request.Nome, turma);

            await repositorioGenerico.AdicionarAsync(professor);

            await repositorioGenerico.SalvarAsync();

            return professor;
        }

        public async Task<List<Professor>> ListarProfessor()
        {
            List<Professor> professores = await repositorioGenerico.RecuperarAsync(null, null, x => x.Usuario, x => x.Turma);

            return professores;
        }
    }
}
