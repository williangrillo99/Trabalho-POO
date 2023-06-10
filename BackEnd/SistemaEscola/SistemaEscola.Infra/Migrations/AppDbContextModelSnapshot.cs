﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaEscola.Infra;

#nullable disable

namespace SistemaEscola.Infra.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SistemaEscola.Dominio.Alunos.Entidade.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("TurmaId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TurmaId");

                    b.HasIndex("UsuarioId")
                        .IsUnique();

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("SistemaEscola.Dominio.Professores.Entidade.Professor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Disciplina")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdUsuario")
                        .IsUnique();

                    b.ToTable("Professores");
                });

            modelBuilder.Entity("SistemaEscola.Dominio.Turmas.Entidade.Turma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProfessorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProfessorId")
                        .IsUnique()
                        .HasFilter("[ProfessorId] IS NOT NULL");

                    b.ToTable("Turmas");
                });

            modelBuilder.Entity("SistemaEscola.Dominio.Usuarios.Entidade.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoUsuarioEnum")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("SistemaEscola.Dominio.Alunos.Entidade.Aluno", b =>
                {
                    b.HasOne("SistemaEscola.Dominio.Turmas.Entidade.Turma", "Turma")
                        .WithMany("Alunos")
                        .HasForeignKey("TurmaId");

                    b.HasOne("SistemaEscola.Dominio.Usuarios.Entidade.Usuario", "Usuario")
                        .WithOne()
                        .HasForeignKey("SistemaEscola.Dominio.Alunos.Entidade.Aluno", "UsuarioId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.OwnsOne("SistemaEscola.Dominio.Enderecos.Entidade.Endereco", "Enderecos", b1 =>
                        {
                            b1.Property<int>("AlunoId")
                                .HasColumnType("int");

                            b1.Property<string>("Cidade")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("AlunoId");

                            b1.ToTable("Alunos");

                            b1.WithOwner()
                                .HasForeignKey("AlunoId");
                        });

                    b.Navigation("Enderecos");

                    b.Navigation("Turma");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("SistemaEscola.Dominio.Professores.Entidade.Professor", b =>
                {
                    b.HasOne("SistemaEscola.Dominio.Usuarios.Entidade.Usuario", "Usuario")
                        .WithOne()
                        .HasForeignKey("SistemaEscola.Dominio.Professores.Entidade.Professor", "IdUsuario")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.OwnsOne("SistemaEscola.Dominio.Enderecos.Entidade.Endereco", "Endereco", b1 =>
                        {
                            b1.Property<int>("ProfessorId")
                                .HasColumnType("int");

                            b1.Property<string>("Cidade")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ProfessorId");

                            b1.ToTable("Professores");

                            b1.WithOwner()
                                .HasForeignKey("ProfessorId");
                        });

                    b.Navigation("Endereco");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("SistemaEscola.Dominio.Turmas.Entidade.Turma", b =>
                {
                    b.HasOne("SistemaEscola.Dominio.Professores.Entidade.Professor", "Professor")
                        .WithOne("Turma")
                        .HasForeignKey("SistemaEscola.Dominio.Turmas.Entidade.Turma", "ProfessorId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("SistemaEscola.Dominio.Professores.Entidade.Professor", b =>
                {
                    b.Navigation("Turma")
                        .IsRequired();
                });

            modelBuilder.Entity("SistemaEscola.Dominio.Turmas.Entidade.Turma", b =>
                {
                    b.Navigation("Alunos");
                });
#pragma warning restore 612, 618
        }
    }
}