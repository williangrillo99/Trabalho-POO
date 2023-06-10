using SistemaEscola.Dominio.Enderecos.Entidade;
using SistemaEscola.Dominio.Turmas.Entidade;
using SistemaEscola.Dominio.Usuarios.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscola.Dominio.Alunos.Entidade
{
    public class Aluno : BaseEntity
    {
        public Usuario Usuario { get; set; } = default!; // ? ou = null! Cria tabela sem o cascate, tirando eles a tabela fica cascate 
        public int UsuarioId { get; set; }       
        public Turma? Turma { get; set; }
        public Endereco? Enderecos { get; set; }
        protected Aluno() { }

        public Aluno(Usuario usuario)
        { 
            Usuario = usuario;
        }
    }
}
