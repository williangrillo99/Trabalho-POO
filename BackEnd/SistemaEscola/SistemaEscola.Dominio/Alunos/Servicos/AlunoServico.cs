using SistemaEscola.Dominio.Alunos.Entidade;
using SistemaEscola.Dominio.Alunos.Servicos.Interface;
using SistemaEscola.Dominio.Professores.Entidade;
using SistemaEscola.Dominio.Repositorio.Interface;
using SistemaEscola.Dominio.Usuarios.Entidade;
using SistemaEscola.Dominio.Usuarios.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscola.Dominio.Alunos.Servicos
{
    public class AlunoServico : IAlunoServico
    {
        private readonly IUsuarioServico usuarioServico;

        private readonly IRepositorioGenerico<Aluno> repositorioGenerico;
        public AlunoServico(IUsuarioServico usuarioServico, IRepositorioGenerico<Aluno> repositorioGenerico)
        {
            this.usuarioServico = usuarioServico;
            this.repositorioGenerico = repositorioGenerico;
        }

        public Aluno Instanciar(string nome)
        {
            Usuario usuario = usuarioServico.InstanciarUsuarioAluno(nome);
            Aluno aluno = new Aluno(usuario);

            return aluno;
        }

        public async Task<Aluno> Validar(int idAluno)
        {
            var aluno = await repositorioGenerico.RecuperarPorIdAsync(idAluno);

            if (aluno == null)
            {
                throw new Exception("Aluno não existe");
            }

            return aluno;
        }
      
    }
}
