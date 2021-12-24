using Microsoft.EntityFrameworkCore.Migrations;

namespace KV.Data.Migrations
{
    public partial class addtbCategoriasAlterColunm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Categorias",
                newName: "Descricao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Categorias",
                newName: "Description");
        }
    }
}
