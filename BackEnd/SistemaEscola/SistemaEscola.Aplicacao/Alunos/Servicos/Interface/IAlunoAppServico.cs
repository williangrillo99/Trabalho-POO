using SistemaEscola.DataTransfer.Alunos;
using SistemaEscola.Dominio.Alunos.Entidade;
using SistemaEscola.Dominio.Usuarios.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscola.Aplicacao.Alunos.Servicos.Interface
{
    public interface IAlunoAppServico
    {
        Task <Aluno> Adicionar(string nome);

        Task<List<AlunoResponse>>ListarAlunos();
        Task<Aluno> RecupearAlunoPorId(int id);
        Task Deletar(int idAluno);
    }
}
