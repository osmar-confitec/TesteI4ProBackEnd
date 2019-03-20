using Microsoft.EntityFrameworkCore.Migrations;

namespace Contatos.Data.Migrations
{
    public partial class Ativos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "TelefonesTel",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "PessoasT",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "EmailsT",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "TelefonesTel");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "PessoasT");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "EmailsT");
        }
    }
}
