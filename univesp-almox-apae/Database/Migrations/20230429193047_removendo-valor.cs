using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace univesp.almox.apae.Database.Migrations
{
    public partial class removendovalor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Valor",
                table: "ItemSaida");

            migrationBuilder.DropColumn(
                name: "Valor",
                table: "ItemEntrada");

            migrationBuilder.DropColumn(
                name: "ValorTotal",
                table: "Estoque");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Valor",
                table: "ItemSaida",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Valor",
                table: "ItemEntrada",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorTotal",
                table: "Estoque",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
