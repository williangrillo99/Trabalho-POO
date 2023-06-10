using SistemaEscola.Aplicacao;
using SistemaEscola.Aplicacao.Usuarios.Servicos.Interface;
using SistemaEscola.Aplicacao.Usuarios.Servicos;
using SistemaEscola.Dominio.Professores.Entidade;
using SistemaEscola.Dominio.Repositorio.Interface;
using SistemaEscola.Dominio.Usuarios.Entidade;
using SistemaEscola.Infra;
using SistemaEscola.Infra.Repositorio;
using System.Net;
using SistemaEscola.Dominio.Usuarios.Servicos;
using System.Reflection;
using SistemaEscola.Dominio.Alunos.Servicos.Interface;
using SistemaEscola.Dominio.Alunos.Servicos;
using SistemaEscola.Aplicacao.Alunos.Servicos.Interface;
using SistemaEscola.Aplicacao.Alunos.Servicos;
using SistemaEscola.Dominio.Alunos.Entidade;
using SistemaEscola.Aplicacao.Professores.Servicos.Interface;
using SistemaEscola.Aplicacao.Professores.Servicos;
using SistemaEscola.Dominio.Professores.Servicos.Interface;
using SistemaEscola.Dominio.Professores.Servicos;
using SistemaEscola.Aplicacao.Turmas.Servicos.Interface;
using SistemaEscola.Aplicacao.Turmas.Servicos;
using SistemaEscola.Dominio.Turmas.Servicos.Interface;
using SistemaEscola.Dominio.Turmas.Servicos;
using SistemaEscola.Dominio.Turmas.Entidade;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Injecao de dependencias - Usuarios
builder.Services.AddScoped<IUsuariosAppServico, UsuariosAppServico>();
builder.Services.AddScoped<IUsuarioServico, UsuarioServico>();
builder.Services.AddScoped<IRepositorioGenerico<Usuario>, RepositorioGenerico<Usuario>>();
builder.Services.AddAutoMapper(typeof(UsuariosAppServico).GetTypeInfo().Assembly); // Vai passar na camada de aplicacao procurando quem herda o Profile

// Injecao de dependencias - Alunos
builder.Services.AddScoped<IAlunoAppServico, AlunoAppServico>();
builder.Services.AddScoped<IAlunoServico, AlunoServico>();
builder.Services.AddScoped<IRepositorioGenerico<Aluno>, RepositorioGenerico<Aluno>>();
builder.Services.AddAutoMapper(typeof(AlunoAppServico).GetTypeInfo().Assembly); // Vai passar na camada de aplicacao procurando quem herda o Profile

// Injecao de dependencias - Professor
builder.Services.AddScoped<IProfessorAppServico, ProfessorAppServico>();
builder.Services.AddScoped<IProfessorServico, ProfessorServico>();
builder.Services.AddScoped<IRepositorioGenerico<Professor>, RepositorioGenerico<Professor>>();

// Injecao de dependencias - Turmas
builder.Services.AddScoped<ITurmaAppServico, TurmaAppServico>();
builder.Services.AddScoped<ITurmaServico, TurmaServico>();
builder.Services.AddScoped<IRepositorioGenerico<Turma>, RepositorioGenerico<Turma>>();

builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Total", builder =>
    {
        builder.WithOrigins().AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();   
    });
});
var app = builder.Build();
app.UseCors("Total");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using(var scope = app.Services.CreateScope())
{
    var dbCotext  = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbCotext.Database.EnsureCreated();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
