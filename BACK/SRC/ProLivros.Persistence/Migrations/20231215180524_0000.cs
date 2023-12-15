using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProLivros.Persistence.Migrations
{
    public partial class _0000 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assunto",
                columns: table => new
                {
                    CodAs = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assunto", x => x.CodAs);
                });

            migrationBuilder.CreateTable(
                name: "Autor",
                columns: table => new
                {
                    CodAu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autor", x => x.CodAu);
                });

            migrationBuilder.CreateTable(
                name: "Livro",
                columns: table => new
                {
                    Codl = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    Editora = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    Edicao = table.Column<int>(type: "int", nullable: false),
                    AnoPublicacao = table.Column<string>(type: "varchar(4)", maxLength: 4, nullable: false),
                    Capa = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    AssuntoCodAs = table.Column<int>(type: "int", nullable: true),
                    AutorCodAu = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livro", x => x.Codl);
                    table.ForeignKey(
                        name: "FK_Livro_Assunto_AssuntoCodAs",
                        column: x => x.AssuntoCodAs,
                        principalTable: "Assunto",
                        principalColumn: "CodAs");
                    table.ForeignKey(
                        name: "FK_Livro_Autor_AutorCodAu",
                        column: x => x.AutorCodAu,
                        principalTable: "Autor",
                        principalColumn: "CodAu");
                });

            migrationBuilder.CreateTable(
                name: "Livro_)Autor",
                columns: table => new
                {
                    Livro_Codl = table.Column<int>(type: "int", nullable: false),
                    Autor_CodAu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Livro_)Autor_Autor_Autor_CodAu",
                        column: x => x.Autor_CodAu,
                        principalTable: "Autor",
                        principalColumn: "CodAu",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Livro_)Autor_Livro_Livro_Codl",
                        column: x => x.Livro_Codl,
                        principalTable: "Livro",
                        principalColumn: "Codl",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Livro_Assunto",
                columns: table => new
                {
                    Livro_Codl = table.Column<int>(type: "int", nullable: false),
                    Assunto_CodAs = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Livro_Assunto_Assunto_Assunto_CodAs",
                        column: x => x.Assunto_CodAs,
                        principalTable: "Assunto",
                        principalColumn: "CodAs",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Livro_Assunto_Livro_Livro_Codl",
                        column: x => x.Livro_Codl,
                        principalTable: "Livro",
                        principalColumn: "Codl",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Livro_AssuntoCodAs",
                table: "Livro",
                column: "AssuntoCodAs");

            migrationBuilder.CreateIndex(
                name: "IX_Livro_AutorCodAu",
                table: "Livro",
                column: "AutorCodAu");

            migrationBuilder.CreateIndex(
                name: "IX_Livro_)Autor_Autor_CodAu",
                table: "Livro_)Autor",
                column: "Autor_CodAu");

            migrationBuilder.CreateIndex(
                name: "IX_Livro_)Autor_Livro_Codl",
                table: "Livro_)Autor",
                column: "Livro_Codl");

            migrationBuilder.CreateIndex(
                name: "IX_Livro_Assunto_Assunto_CodAs",
                table: "Livro_Assunto",
                column: "Assunto_CodAs");

            migrationBuilder.CreateIndex(
                name: "IX_Livro_Assunto_Livro_Codl",
                table: "Livro_Assunto",
                column: "Livro_Codl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Livro_)Autor");

            migrationBuilder.DropTable(
                name: "Livro_Assunto");

            migrationBuilder.DropTable(
                name: "Livro");

            migrationBuilder.DropTable(
                name: "Assunto");

            migrationBuilder.DropTable(
                name: "Autor");
        }
    }
}
