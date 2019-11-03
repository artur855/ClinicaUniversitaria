using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Hospital.Infra.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_usuarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    nome = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: false),
                    senha = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_usuarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_medicos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    crm = table.Column<string>(nullable: false),
                    id_usuario = table.Column<int>(nullable: false),
                    tipo_medico = table.Column<int>(nullable: false),
                    titulacao = table.Column<string>(type: "VARCHAR(45)", nullable: true),
                    ano_inicio = table.Column<DateTime>(type: "DATE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_medicos", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_medicos_tb_usuarios_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "tb_usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_pacientes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    sexo = table.Column<char>(nullable: false),
                    cor = table.Column<int>(nullable: false),
                    dt_nasc = table.Column<DateTime>(nullable: false),
                    id_usuario = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_pacientes", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_pacientes_tb_usuarios_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "tb_usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_pedidos_exames",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    hipotese_cid = table.Column<string>(nullable: true),
                    recomendacao = table.Column<string>(nullable: true),
                    data_prevista = table.Column<DateTime>(nullable: false),
                    exame = table.Column<int>(nullable: false),
                    id_medico = table.Column<int>(nullable: false),
                    id_paciente = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_pedidos_exames", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_pedidos_exames_tb_medicos_id_medico",
                        column: x => x.id_medico,
                        principalTable: "tb_medicos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_pedidos_exames_tb_pacientes_id_paciente",
                        column: x => x.id_paciente,
                        principalTable: "tb_pacientes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_medicos_id_usuario",
                table: "tb_medicos",
                column: "id_usuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_pacientes_id_usuario",
                table: "tb_pacientes",
                column: "id_usuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_pedidos_exames_id_medico",
                table: "tb_pedidos_exames",
                column: "id_medico");

            migrationBuilder.CreateIndex(
                name: "IX_tb_pedidos_exames_id_paciente",
                table: "tb_pedidos_exames",
                column: "id_paciente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_pedidos_exames");

            migrationBuilder.DropTable(
                name: "tb_medicos");

            migrationBuilder.DropTable(
                name: "tb_pacientes");

            migrationBuilder.DropTable(
                name: "tb_usuarios");
        }
    }
}
