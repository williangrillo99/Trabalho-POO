using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaEscola.Infra.Migrations
{
    /// <inheritdoc />
    public partial class teste4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Endereco_Cidade",
                table: "Professores",
                type: "nvarchar(max)",
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Endereco_Bairro",
                table: "Professores");

            migrationBuilder.DropColumn(
                name: "Endereco_Cep",
                table: "Professores");

            migrationBuilder.DropColumn(
                name: "Endereco_Cidade",
                table: "Professores");

            migrationBuilder.DropColumn(
                name: "Endereco_Numero",
                table: "Professores");

            migrationBuilder.DropColumn(
                name: "Endereco_Rua",
                table: "Professores");
        }
    }
}
