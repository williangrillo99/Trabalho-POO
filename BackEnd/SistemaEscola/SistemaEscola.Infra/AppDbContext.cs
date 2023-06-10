using Microsoft.EntityFrameworkCore;
using SistemaEscola.Dominio.Alunos.Entidade;
using SistemaEscola.Dominio.Enderecos.Entidade;
using SistemaEscola.Dominio.Professores.Entidade;
using SistemaEscola.Dominio.Turmas.Entidade;
using SistemaEscola.Dominio.Usuarios.Entidade;

namespace SistemaEscola.Infra
{
    public class AppDbContext : DbContext
    {
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = localhost, 1433; Database = SistemaEscola990; User ID = sa; Password = 1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True;", b => b.MigrationsAssembly("SistemaEscola.Infra"));
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasKey(x => x.Id);
            modelBuilder.Entity<Aluno>().HasKey(x => x.Id);
            modelBuilder.Entity<Professor>().HasKey(x => x.Id);
            modelBuilder.Entity<Turma>().HasKey(x => x.Id);

            modelBuilder.Entity<Aluno>().OwnsOne<Endereco>(x => x.Enderecos);
            modelBuilder.Entity<Professor>().OwnsOne<Endereco>(x => x.Endereco);

            modelBuilder.Entity<Professor>()
                .HasOne(x => x.Usuario)
                .WithOne()
                .HasForeignKey<Professor>(x => x.IdUsuario)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Turma>()
                .HasOne(x => x.Professor)
                .WithOne(x => x.Turma)
                .HasForeignKey<Turma>(x => x.ProfessorId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Aluno>()
                .HasOne(x => x.Usuario)
                .WithOne()
                .HasForeignKey<Aluno>(x => x.UsuarioId)
                .OnDelete(DeleteBehavior.NoAction);


           

            //Quando a entidade se relaciona com duas entidade, precisa colocar uma propriedade Id pra ela, ou entao ela é uma propriedade da classe

            base.OnModelCreating(modelBuilder);
        }
    }

}