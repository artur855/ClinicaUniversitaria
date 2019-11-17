using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Hospital.Infra.Data.Migrations
{
    public partial class AddExam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExamId",
                table: "tb_pedidos_exames",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "id_exam_report",
                table: "tb_pedidos_exames",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "tb_exames",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    caminho_exame = table.Column<string>(type: "varchar(300)", nullable: true),
                    data = table.Column<DateTime>(type: "date", nullable: false),
                    ExamRequestId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_exames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_exames_tb_pedidos_exames_Id",
                        column: x => x.Id,
                        principalTable: "tb_pedidos_exames",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_pedidos_laudos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ExamRequestId = table.Column<int>(nullable: false),
                    ResidentId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    cid = table.Column<int>(nullable: false),
                    ExamId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_pedidos_laudos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_pedidos_laudos_tb_exames_ExamId",
                        column: x => x.ExamId,
                        principalTable: "tb_exames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_pedidos_laudos_tb_pedidos_exames_ExamRequestId",
                        column: x => x.ExamRequestId,
                        principalTable: "tb_pedidos_exames",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_pedidos_laudos_tb_medicos_ResidentId",
                        column: x => x.ResidentId,
                        principalTable: "tb_medicos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_pedidos_laudos_ExamId",
                table: "tb_pedidos_laudos",
                column: "ExamId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_pedidos_laudos_ExamRequestId",
                table: "tb_pedidos_laudos",
                column: "ExamRequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_pedidos_laudos_ResidentId",
                table: "tb_pedidos_laudos",
                column: "ResidentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_pedidos_laudos");

            migrationBuilder.DropTable(
                name: "tb_exames");

            migrationBuilder.DropColumn(
                name: "ExamId",
                table: "tb_pedidos_exames");

            migrationBuilder.DropColumn(
                name: "id_exam_report",
                table: "tb_pedidos_exames");
        }
    }
}
