using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace univesp.almox.apae.Database.Migrations
{
    public partial class removendosigla : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estoque_Unidade_MedidaId",
                table: "Estoque");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemEntrada_Unidade_MedidaId",
                table: "ItemEntrada");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemSaida_Unidade_MedidaId",
                table: "ItemSaida");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Unidade",
                table: "Unidade");

            migrationBuilder.DropColumn(
                name: "Sigla",
                table: "Unidade");

            migrationBuilder.RenameTable(
                name: "Unidade",
                newName: "Medida");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Medida",
                table: "Medida",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Estoque_Medida_MedidaId",
                table: "Estoque",
                column: "MedidaId",
                principalTable: "Medida",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemEntrada_Medida_MedidaId",
                table: "ItemEntrada",
                column: "MedidaId",
                principalTable: "Medida",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemSaida_Medida_MedidaId",
                table: "ItemSaida",
                column: "MedidaId",
                principalTable: "Medida",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estoque_Medida_MedidaId",
                table: "Estoque");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemEntrada_Medida_MedidaId",
                table: "ItemEntrada");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemSaida_Medida_MedidaId",
                table: "ItemSaida");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Medida",
                table: "Medida");

            migrationBuilder.RenameTable(
                name: "Medida",
                newName: "Unidade");

            migrationBuilder.AddColumn<string>(
                name: "Sigla",
                table: "Unidade",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Unidade",
                table: "Unidade",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Estoque_Unidade_MedidaId",
                table: "Estoque",
                column: "MedidaId",
                principalTable: "Unidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemEntrada_Unidade_MedidaId",
                table: "ItemEntrada",
                column: "MedidaId",
                principalTable: "Unidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemSaida_Unidade_MedidaId",
                table: "ItemSaida",
                column: "MedidaId",
                principalTable: "Unidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
