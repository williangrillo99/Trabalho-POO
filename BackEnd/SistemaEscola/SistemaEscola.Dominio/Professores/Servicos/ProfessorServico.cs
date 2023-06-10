using SistemaEscola.Dominio.Professores.Entidade;
using SistemaEscola.Dominio.Professores.Servicos.Interface;
using SistemaEscola.Dominio.Repositorio.Interface;
using SistemaEscola.Dominio.Turmas.Entidade;
using SistemaEscola.Dominio.Turmas.Servicos.Interface;
using SistemaEscola.Dominio.Usuarios.Entidade;
using SistemaEscola.Dominio.Usuarios.Servicos;

namespace SistemaEscola.Dominio.Professores.Servicos
{
    public class ProfessorServico : IProfessorServico
    {
        private readonly IUsuarioServico  usuarioServico;
        private readonly IRepositorioGenerico<Professor> repositorioGenerico;
        public ProfessorServico(IUsuarioServico usuarioServico, IRepositorioGenerico<Professor> repositorioGenerico, ITurmaServico turmaServico)
        {
            this.usuarioServico = usuarioServico;
            this.repositorioGenerico = repositorioGenerico;
        }
        public async Task <Professor> Instanciar(string nome, Turma turma)
        {
            Usuario usuario = usuarioServico.InstanciarUsuarioProfessor(nome);

            Professor professor = new Professor(nome, usuario, turma);

            return professor;
        }
        public async Task<Professor> Validar(int id)
        {
            var professor = await repositorioGenerico.RecuperarPorIdAsync(id);

            if (professor == null)
            {
                throw new Exception("Professor não existe");
            }
            return professor;
        }
    }
}
