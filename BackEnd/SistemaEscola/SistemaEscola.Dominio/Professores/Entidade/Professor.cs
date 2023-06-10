using SistemaEscola.Dominio.Enderecos.Entidade;
using SistemaEscola.Dominio.Turmas.Entidade;
using SistemaEscola.Dominio.Usuarios.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscola.Dominio.Professores.Entidade
{
    public class Professor : BaseEntity
    {
        public string? Nome { get; set; } 
        public string? Disciplina { get; set; } 
        public Usuario Usuario { get; set; } = default!;
        public int IdUsuario { get; set; }
        public Turma Turma { get; set; } = default!;
        public Endereco? Endereco { get; set; }
        protected Professor() { }

        public Professor(string nome, Usuario usuario, Turma turma)
        {
            Nome = nome;    
            Usuario = usuario;
            Turma = turma;
        }
    }
 
}
