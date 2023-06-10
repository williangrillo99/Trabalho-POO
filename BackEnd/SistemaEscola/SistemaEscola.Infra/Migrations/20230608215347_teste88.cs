using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaEscola.Infra.Migrations
{
    /// <inheritdoc />
    public partial class teste88 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Endereco_Bairro",
                table: "Professores");

            migrationBuilder.DropColumn(
                name: "Endereco_Cep",
                table: "Professores");

            migrationBuilder.DropColumn(
                name: "Endereco_Numero",
                table: "Professores");

            migrationBuilder.DropColumn(
                name: "Endereco_Rua",
                table: "Professores");

            migrationBuilder.DropColumn(
                name: "Enderecos_Bairro",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "Enderecos_Cep",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "Enderecos_Numero",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "Enderecos_Rua",
                table: "Alunos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Endereco_Bairro",
                table: "Professores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Endereco_Cep",
                table: "Professores",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Endereco_Numero",
                table: "Professores",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Endereco_Rua",
                table: "Professores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Enderecos_Bairro",
                table: "Alunos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Enderecos_Cep",
                table: "Alunos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Enderecos_Numero",
                table: "Alunos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Enderecos_Rua",
                table: "Alunos",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
