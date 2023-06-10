using SistemaEscola.Dominio.Enderecos.Entidade;
using SistemaEscola.Dominio.Turmas.Entidade;
using SistemaEscola.Dominio.Usuarios.Entidade;

namespace SistemaEscola.DataTransfer.Alunos
{
    public class AlunoResponse
    {
        public int Id { get; set; }
        public Usuario? Usuario { get; set; } 
        public int UsuarioId { get; set; }
        public List<Turma>? Turmas { get; set; }
        public Endereco? Enderecos { get; set; }

    }
}