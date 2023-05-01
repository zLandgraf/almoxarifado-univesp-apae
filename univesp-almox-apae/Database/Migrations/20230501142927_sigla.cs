using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace univesp.almox.apae.Database.Migrations
{
    public partial class sigla : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Sigla",
                table: "Medida",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sigla",
                table: "Medida");
        }
    }
}
