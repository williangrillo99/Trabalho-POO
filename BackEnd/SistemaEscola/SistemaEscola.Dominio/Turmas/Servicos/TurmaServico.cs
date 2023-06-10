using SistemaEscola.Dominio.Alunos.Entidade;
using SistemaEscola.Dominio.Alunos.Servicos.Interface;
using SistemaEscola.Dominio.Professores.Entidade;
using SistemaEscola.Dominio.Professores.Servicos.Interface;
using SistemaEscola.Dominio.Repositorio.Interface;
using SistemaEscola.Dominio.Turmas.Entidade;
using SistemaEscola.Dominio.Turmas.Servicos.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscola.Dominio.Turmas.Servicos
{
    public class TurmaServico : ITurmaServico
    {
        private readonly IRepositorioGenerico<Turma> repositorioGenerico;
        private readonly IAlunoServico alunoServico;
        public TurmaServico(IRepositorioGenerico<Turma> repositorioGenerico, IAlunoServico alunoServico)
        {
            this.repositorioGenerico = repositorioGenerico;
            this.alunoServico = alunoServico;
        }
        public async Task<Turma> Instanciar(string nome, int[] idAlunos)
        {
            Turma turma = new Turma(nome);

            foreach(int idAluno in idAlunos) {

                Aluno aluno = await alunoServico.Validar(idAluno);

                turma.Alunos.Add(aluno);

            }

            return turma;
        }

        public async Task <Turma> Validar(int id)
        {
            var turma =  await repositorioGenerico.RecuperarPorIdAsync(id);

            if (turma == null)
            {
                throw new Exception("Turma nao existe");
            }

            return turma;   
        }
    }
}
