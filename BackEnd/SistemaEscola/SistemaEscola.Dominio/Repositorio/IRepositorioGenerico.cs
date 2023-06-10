using Microsoft.EntityFrameworkCore;
using SistemaEscola.Dominio.Alunos.Entidade;
using SistemaEscola.Dominio.Usuarios.Entidade;
using System.Linq.Expressions;

namespace SistemaEscola.Dominio.Repositorio.Interface
{
    public interface IRepositorioGenerico<T> where T : BaseEntity
    {
        Task<T> AdicionarAsync(T entity);
        void AtualizarAsync(T entity);
        void DeletarAsync(T entity);
        //Task<List<T>> FiltrarAsync(Expression<Func<T, bool>>[] filters, int? skip, int? take, params Expression<Func<T, object>>[] includes);
        Task<List<T>> RecuperarAsync(int? skip, int? take, params Expression<Func<T, object>>[] includes);
        Task<T?> RecuperarPorIdAsync(int id, params Expression<Func<T, object>>[] includes);
        Task SalvarAsync();
        Usuario Logar(string login, string senha);
    }
}