using Microsoft.EntityFrameworkCore.Migrations;

namespace Hospital.Infra.Data.Migrations
{
    public partial class ChangeColumnNameExamReport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_pedidos_laudos_tb_medicos_ResidentId",
                table: "tb_pedidos_laudos");

            migrationBuilder.RenameColumn(
                name: "ResidentId",
                table: "tb_pedidos_laudos",
                newName: "MedicId");

            migrationBuilder.RenameIndex(
                name: "IX_tb_pedidos_laudos_ResidentId",
                table: "tb_pedidos_laudos",
                newName: "IX_tb_pedidos_laudos_MedicId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_pedidos_laudos_tb_medicos_MedicId",
                table: "tb_pedidos_laudos",
                column: "MedicId",
                principalTable: "tb_medicos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_pedidos_laudos_tb_medicos_MedicId",
                table: "tb_pedidos_laudos");

            migrationBuilder.RenameColumn(
                name: "MedicId",
                table: "tb_pedidos_laudos",
                newName: "ResidentId");

            migrationBuilder.RenameIndex(
                name: "IX_tb_pedidos_laudos_MedicId",
                table: "tb_pedidos_laudos",
                newName: "IX_tb_pedidos_laudos_ResidentId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_pedidos_laudos_tb_medicos_ResidentId",
                table: "tb_pedidos_laudos",
                column: "ResidentId",
                principalTable: "tb_medicos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
