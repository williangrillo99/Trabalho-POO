using Microsoft.EntityFrameworkCore;
using SistemaEscola.Dominio.Repositorio.Interface;
using SistemaEscola.Dominio.Usuarios.Entidade;
using SistemaEscola.Dominio.Usuarios.Enum;
using SistemaEscola.Dominio.Usuarios.Servicos.Comandos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscola.Dominio.Usuarios.Servicos
{
    public class UsuarioServico : IUsuarioServico
    {
        private readonly IRepositorioGenerico<Usuario> repositorioGenerico;

        public UsuarioServico(IRepositorioGenerico<Usuario> repositorioGenerico)
        {
            this.repositorioGenerico = repositorioGenerico;
        }

        public Usuario InstanciarUsuarioAdmin(string nome)
        {
            Usuario usuario = new Usuario(nome);
            usuario.Nome = nome;
            usuario.Email = $"{nome}@teste.com.br";
            usuario.Senha = "senhapadrao";
            usuario.DataCriacao = DateTime.Now;
            usuario.TipoUsuarioEnum = TipoUsuarioEnum.Admin;
            return usuario;
        }
        public Usuario InstanciarUsuarioAluno(string nome)
        {
            Usuario usuario = new Usuario(nome);
            usuario.Nome = nome;
            usuario.Email = $"{nome}@teste.com.br";
            usuario.Senha = "senhapadrao";
            usuario.DataCriacao = DateTime.Now;
            usuario.TipoUsuarioEnum = TipoUsuarioEnum.Aluno;
            return usuario;

        }

        public Usuario InstanciarUsuarioProfessor(string nome)
        {
            Usuario usuario = new Usuario(nome);
            usuario.Email = $"{nome}@teste.com.br";
            usuario.Senha = "senhapadrao";
            usuario.DataCriacao = DateTime.Now;
            usuario.TipoUsuarioEnum = TipoUsuarioEnum.Professor;
            return usuario;

        }
        public async Task<Usuario> ValidarUsuario(int usuarioId)
        {
            var usuario = await repositorioGenerico.RecuperarPorIdAsync(usuarioId);

            if (usuario == null)
            {
                throw new Exception("Usuario não existe");
            }
            return usuario;
        }
        public async Task<Usuario> Atualizar(int id, UsuarioAtualizarComando comando)
        {
            var usuario = await ValidarUsuario(id);

            return usuario;
        }

    }
}
