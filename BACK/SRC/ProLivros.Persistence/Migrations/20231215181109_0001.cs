using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProLivros.Persistence.Migrations
{
    public partial class _0001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livro_)Autor_Autor_Autor_CodAu",
                table: "Livro_)Autor");

            migrationBuilder.DropForeignKey(
                name: "FK_Livro_)Autor_Livro_Livro_Codl",
                table: "Livro_)Autor");

            migrationBuilder.RenameTable(
                name: "Livro_)Autor",
                newName: "Livro_Autor");

            migrationBuilder.RenameIndex(
                name: "IX_Livro_)Autor_Livro_Codl",
                table: "Livro_Autor",
                newName: "IX_Livro_Autor_Livro_Codl");

            migrationBuilder.RenameIndex(
                name: "IX_Livro_)Autor_Autor_CodAu",
                table: "Livro_Autor",
                newName: "IX_Livro_Autor_Autor_CodAu");

            migrationBuilder.AddForeignKey(
                name: "FK_Livro_Autor_Autor_Autor_CodAu",
                table: "Livro_Autor",
                column: "Autor_CodAu",
                principalTable: "Autor",
                principalColumn: "CodAu",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Livro_Autor_Livro_Livro_Codl",
                table: "Livro_Autor",
                column: "Livro_Codl",
                principalTable: "Livro",
                principalColumn: "Codl",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livro_Autor_Autor_Autor_CodAu",
                table: "Livro_Autor");

            migrationBuilder.DropForeignKey(
                name: "FK_Livro_Autor_Livro_Livro_Codl",
                table: "Livro_Autor");

            migrationBuilder.RenameTable(
                name: "Livro_Autor",
                newName: "Livro_)Autor");

            migrationBuilder.RenameIndex(
                name: "IX_Livro_Autor_Livro_Codl",
                table: "Livro_)Autor",
                newName: "IX_Livro_)Autor_Livro_Codl");

            migrationBuilder.RenameIndex(
                name: "IX_Livro_Autor_Autor_CodAu",
                table: "Livro_)Autor",
                newName: "IX_Livro_)Autor_Autor_CodAu");

            migrationBuilder.AddForeignKey(
                name: "FK_Livro_)Autor_Autor_Autor_CodAu",
                table: "Livro_)Autor",
                column: "Autor_CodAu",
                principalTable: "Autor",
                principalColumn: "CodAu",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Livro_)Autor_Livro_Livro_Codl",
                table: "Livro_)Autor",
                column: "Livro_Codl",
                principalTable: "Livro",
                principalColumn: "Codl",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
