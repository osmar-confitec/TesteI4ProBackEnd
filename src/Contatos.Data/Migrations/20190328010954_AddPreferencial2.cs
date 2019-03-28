using Microsoft.EntityFrameworkCore.Migrations;

namespace Contatos.Data.Migrations
{
    public partial class AddPreferencial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Preferencial",
                table: "PessoasT",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Preferencial",
                table: "PessoasT");
        }
    }
}
