using SistemaEscola.Dominio.Professores.Entidade;
using SistemaEscola.Dominio.Turmas.Entidade;
using SistemaEscola.Dominio.Usuarios.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscola.Dominio.Professores.Servicos.Interface
{
    public interface IProfessorServico
    {
        Task<Professor> Instanciar(string nome, Turma turma);

        Task<Professor> Validar(int id);

    }
}
