using Microsoft.EntityFrameworkCore;
using SistemaEscola.Dominio;
using SistemaEscola.Dominio.Alunos.Entidade;
using SistemaEscola.Dominio.Repositorio.Interface;
using SistemaEscola.Dominio.Usuarios.Entidade;
using System.Linq.Expressions;

namespace SistemaEscola.Infra.Repositorio
{
    public class RepositorioGenerico<T> : IRepositorioGenerico<T> where T : BaseEntity
    {
        private AppDbContext appDbContext { get; }
        private DbSet<T> DbSet { get; }
        public RepositorioGenerico(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
            DbSet = appDbContext.Set<T>();
        }

        public Usuario Logar(string login, string senha)
        {

            IQueryable<Usuario> query = appDbContext.Usuarios.AsQueryable();
           
            var usuario = query.FirstOrDefault(x => x.Login == login);

            return usuario;
        }

        public async Task<T> AdicionarAsync(T entity)
        {
            await DbSet.AddAsync(entity);
            return entity;
        }

        public void AtualizarAsync(T entity)
        {
            DbSet.Attach(entity);
            appDbContext.Entry(entity).State = EntityState.Modified;
        }

        public void DeletarAsync(T entity)
        {
            if (appDbContext.Entry(entity).State == EntityState.Detached)
                DbSet.Attach(entity);
            DbSet.Remove(entity);

        }
        //public async Task<List<T>> FiltrarAsync(Expression<Func<T, bool>>[] filters, int? skip, int? take, params System.Linq.Expressions.Expression<Func<T, object>>[] includes)
        //{
        //    IQueryable<T> query = DbSet;

        //    foreach(var filter in filters) 
        //        query = query.Where(filter);
        //    foreach(var include in includes)
        //        query = query.Include(include);

        //    if (skip != null)
        //        query = query.Skip(skip.Value);

        //    if(take != null)
        //        query = query.Take(take.Value);

        //    return await query.ToListAsync();
        //}

        public async Task<List<T>> RecuperarAsync(int? skip, int? take, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = DbSet;

            foreach (var include in includes)
                query = query.Include(include);

            if (skip != null)
                query = query.Skip(skip.Value);
            if (take != null)
                query = query.Take(take.Value);

            return await query.ToListAsync();
        }
    
        public Task<T?> RecuperarPorIdAsync(int id, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = DbSet;

            query = query.Where(x => x.Id == id);

            foreach (var include in includes)
                query = query.Include(include);

            return query.SingleOrDefaultAsync();
        }

        public async Task SalvarAsync()
        {
            await appDbContext.SaveChangesAsync();
        }

    }


}
