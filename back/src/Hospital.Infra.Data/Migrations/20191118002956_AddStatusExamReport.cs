using Microsoft.EntityFrameworkCore.Migrations;

namespace Hospital.Infra.Data.Migrations
{
    public partial class AddStatusExamReport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "tb_pedidos_laudos",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "tb_pedidos_laudos");
        }
    }
}
