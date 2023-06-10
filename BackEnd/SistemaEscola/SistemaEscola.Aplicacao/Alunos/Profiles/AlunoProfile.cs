using AutoMapper;
using SistemaEscola.DataTransfer.Alunos;
using SistemaEscola.Dominio.Alunos.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscola.Aplicacao.Alunos.Profiles
{
    public class AlunoProfile : Profile
    {
        public AlunoProfile() 
        { 
            CreateMap<Aluno, AlunoResponse>();
        }

    }
}
