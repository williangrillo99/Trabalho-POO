using AutoMapper;
using SistemaEscola.Aplicacao.Alunos.Servicos.Interface;
using SistemaEscola.Aplicacao.Usuarios.Servicos.Interface;
using SistemaEscola.DataTransfer.Alunos;
using SistemaEscola.Dominio.Alunos.Entidade;
using SistemaEscola.Dominio.Alunos.Servicos.Interface;
using SistemaEscola.Dominio.Repositorio.Interface;
using SistemaEscola.Dominio.Usuarios.Entidade;
using SistemaEscola.Dominio.Usuarios.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscola.Aplicacao.Alunos.Servicos
{
    public class AlunoAppServico : IAlunoAppServico
    {
        private readonly IRepositorioGenerico<Aluno> repositorioGenerico;
        private readonly IAlunoServico alunoServico;
        private readonly IMapper mapper;
        public AlunoAppServico(IRepositorioGenerico<Aluno> repositorioGenerico,
                               IAlunoServico alunoServico,
                               IMapper mapper)
        {
            this.repositorioGenerico = repositorioGenerico;
            this.alunoServico = alunoServico;
            this.mapper = mapper;
        }

        public async Task<Aluno> Adicionar(string nome)
        {

            var aluno = alunoServico.Instanciar(nome);

            await repositorioGenerico.AdicionarAsync(aluno);

            await repositorioGenerico.SalvarAsync();

            return aluno;
        }
        public async Task<List<AlunoResponse>> ListarAlunos()
        {
            var alunos = await repositorioGenerico.RecuperarAsync(null, null, x => x.Usuario);

            var response = mapper.Map<List<AlunoResponse>>(alunos);

            return response;
        }

        public async Task<Aluno> RecupearAlunoPorId(int id)
        {
            var aluno = await repositorioGenerico.RecuperarPorIdAsync(id, x => x.Usuario);
            mapper.Map<Aluno>(aluno);
            if(aluno == null)
            {
                throw new Exception("Aluno nao existe");
            }
            return aluno;
        }
        public async Task Deletar(int idAluno)
        {
            var usuariodeletado = await repositorioGenerico.RecuperarPorIdAsync(idAluno);

            if(usuariodeletado == null)
            {
                throw new Exception("Aluno nao encontrado");
            }

            repositorioGenerico.DeletarAsync(usuariodeletado);

            await repositorioGenerico.SalvarAsync();

        }
    }
}
