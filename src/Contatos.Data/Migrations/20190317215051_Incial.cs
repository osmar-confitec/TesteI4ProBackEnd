using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Contatos.Data.Migrations
{
    public partial class Incial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PessoasT",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(300)", nullable: false),
                    Email = table.Column<string>(type: "varchar(300)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoasT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmailsT",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EnderecoEmail = table.Column<string>(type: "varchar(300)", nullable: false),
                    PessoaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailsT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailsT_PessoasT_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "PessoasT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TelefonesTel",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NumeroTelefone = table.Column<string>(type: "varchar(20)", nullable: false),
                    PessoaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelefonesTel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TelefonesTel_PessoasT_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "PessoasT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmailsT_PessoaId",
                table: "EmailsT",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_TelefonesTel_PessoaId",
                table: "TelefonesTel",
                column: "PessoaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailsT");

            migrationBuilder.DropTable(
                name: "TelefonesTel");

            migrationBuilder.DropTable(
                name: "PessoasT");
        }
    }
}
