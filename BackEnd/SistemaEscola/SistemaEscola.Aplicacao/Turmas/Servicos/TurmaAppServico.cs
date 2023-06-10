using SistemaEscola.Aplicacao.Turmas.Servicos.Interface;
using SistemaEscola.Dominio.Repositorio.Interface;
using SistemaEscola.Dominio.Turmas.Entidade;
using SistemaEscola.Dominio.Turmas.Servicos.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscola.Aplicacao.Turmas.Servicos
{
    public class TurmaAppServico : ITurmaAppServico
    {
        private readonly IRepositorioGenerico<Turma> repositorioGenerico;
        private readonly ITurmaServico turmaServico;
     
        public TurmaAppServico(IRepositorioGenerico<Turma> repositorioGenerico, ITurmaServico turmaServico)
        {
            this.repositorioGenerico = repositorioGenerico;
            this.turmaServico = turmaServico;
        }

        public async Task<Turma> Adicionar(string nome, int[] idAlunos)
        {

            var turma = await turmaServico.Instanciar(nome,  idAlunos);

            await repositorioGenerico.AdicionarAsync(turma);

            await repositorioGenerico.SalvarAsync();

            return turma;
        }

        public async Task<List<Turma>> Listar()
        {
            var turmas = await repositorioGenerico.RecuperarAsync(null, null);

            return turmas;

        }

        public async Task<Turma> Recuperar(int id)
        {
            Turma turma = await turmaServico.Validar(id);

            return turma;
        }
    }
}
