using SistemaEscola.Dominio.Alunos.Entidade;
using SistemaEscola.Dominio.Professores.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscola.Dominio.Turmas.Entidade
{
    public class Turma : BaseEntity
    {
        public string Nome { get; set; } = null!;
        public List<Aluno>? Alunos { get; set; }
        public Professor? Professor { get; set; } 
        public int? ProfessorId { get; set; }   
        protected Turma() { }

        public Turma(string nome)
        {
            SetNome(nome);
        }
        void SetNome(string nome)
        {
            Nome = nome;
        }
    }
}
