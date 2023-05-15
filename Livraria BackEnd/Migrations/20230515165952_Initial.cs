using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Livraria_BackEnd.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Livros",
                columns: table => new
                {
                    Codigo = table.Column<Guid>(nullable: false),
                    CodEditora = table.Column<int>(nullable: false),
                    Titulo = table.Column<string>(maxLength: 30, nullable: false),
                    Resumo = table.Column<string>(nullable: true),
                    Autores = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livros", x => x.Codigo);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Livros");
        }
    }
}
