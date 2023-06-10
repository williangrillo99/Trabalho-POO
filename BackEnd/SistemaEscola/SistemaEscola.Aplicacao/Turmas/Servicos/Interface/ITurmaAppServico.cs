using SistemaEscola.Dominio.Turmas.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscola.Aplicacao.Turmas.Servicos.Interface
{
    public interface ITurmaAppServico
    {
        Task<Turma> Adicionar(string nome,  int[] idAlunos);

        Task<List<Turma>> Listar();

        Task<Turma> Recuperar(int id);
    }
}
