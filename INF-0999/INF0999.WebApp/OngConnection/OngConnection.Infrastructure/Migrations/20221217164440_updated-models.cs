using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OngConnection.Infrastructure.Migrations
{
    public partial class updatedmodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Responsavel",
                table: "FAMILIES",
                newName: "Observacoes");

            migrationBuilder.AddColumn<string>(
                name: "CEP",
                table: "ONGS",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "ONGS",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "ONGS",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CEP",
                table: "FAMILIES",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "FAMILIES",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "FAMILIES",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "FAMILIES",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CEP",
                table: "ONGS");

            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "ONGS");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "ONGS");

            migrationBuilder.DropColumn(
                name: "CEP",
                table: "FAMILIES");

            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "FAMILIES");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "FAMILIES");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "FAMILIES");

            migrationBuilder.RenameColumn(
                name: "Observacoes",
                table: "FAMILIES",
                newName: "Responsavel");
        }
    }
}
