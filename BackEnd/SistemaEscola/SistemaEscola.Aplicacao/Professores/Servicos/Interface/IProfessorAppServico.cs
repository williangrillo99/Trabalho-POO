using SistemaEscola.DataTransfer.Professores;
using SistemaEscola.Dominio.Professores.Entidade;
using SistemaEscola.Dominio.Usuarios.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscola.Aplicacao.Professores.Servicos.Interface
{
    public interface IProfessorAppServico
    {
        Task<Professor> Adicionar(ProfessorRequest request);
        Task<List<Professor>> ListarProfessor();
    }
}
