using SistemaEscola.Dominio.Alunos.Entidade;
using SistemaEscola.Dominio.Usuarios.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscola.Dominio.Alunos.Servicos.Interface
{
    public interface IAlunoServico
    {
        Aluno Instanciar(string nome);

        Task<Aluno> Validar(int idAluno);
    }
}
