using SistemaEscola.Dominio.Professores.Entidade;
using SistemaEscola.Dominio.Usuarios.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscola.Dominio.Usuarios.Entidade
{
    public class Usuario : BaseEntity
    {
        public string? Nome { get; set; }
        public string Login { get; set; } = null!;
        public string Senha { get; set; } = null!;
        public string? Email { get; set; } // ? Aceita o campo nulo no banco sem mapear
        public TipoUsuarioEnum TipoUsuarioEnum { get; set; }
        public DateTime DataCriacao { get; set; }
        protected Usuario() { } //Nao deixa instacinar, apenas com o construtor

        public Usuario(string nome)
        {
            Nome = nome;
            Login = nome;
            Senha = Guid.NewGuid().ToString();
        }
        // Fazer validacao de nome e gerar um login de acordo com o nome
    }
}
