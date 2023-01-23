using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OngConnection.Infrastructure.Migrations
{
    public partial class modelchangefamily : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "FAMILIES",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "FAMILIES");
        }
    }
}
