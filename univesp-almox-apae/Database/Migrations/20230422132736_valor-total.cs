using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace univesp.almox.apae.Database.Migrations
{
    public partial class valortotal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ValorMedio",
                table: "Estoque",
                newName: "ValorTotal");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ValorTotal",
                table: "Estoque",
                newName: "ValorMedio");
        }
    }
}
