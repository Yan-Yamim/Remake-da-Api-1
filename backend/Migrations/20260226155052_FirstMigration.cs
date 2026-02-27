using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Grupo",
                columns: table => new
                {
                    id_grupo = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome_grupo = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupo", x => x.id_grupo);
                });

            migrationBuilder.CreateTable(
                name: "Turma",
                columns: table => new
                {
                    turma_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome_turma = table.Column<string>(type: "text", nullable: false),
                    qtd_aluno = table.Column<int>(type: "integer", nullable: false),
                    qtd_ciclos = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turma", x => x.turma_id);
                });

            migrationBuilder.CreateTable(
                name: "Aluno",
                columns: table => new
                {
                    aluno_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome_aluno = table.Column<string>(type: "text", nullable: false),
                    sobrenome = table.Column<string>(type: "text", nullable: false),
                    idade = table.Column<int>(type: "integer", nullable: false),
                    ra = table.Column<int>(type: "integer", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    grupoId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno", x => x.aluno_id);
                    table.ForeignKey(
                        name: "FK_Aluno_Grupo_grupoId",
                        column: x => x.grupoId,
                        principalTable: "Grupo",
                        principalColumn: "id_grupo");
                });

            migrationBuilder.CreateTable(
                name: "AlunoTurma",
                columns: table => new
                {
                    AlunosalunoId = table.Column<long>(type: "bigint", nullable: false),
                    TurmasturmaId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoTurma", x => new { x.AlunosalunoId, x.TurmasturmaId });
                    table.ForeignKey(
                        name: "FK_AlunoTurma_Aluno_AlunosalunoId",
                        column: x => x.AlunosalunoId,
                        principalTable: "Aluno",
                        principalColumn: "aluno_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunoTurma_Turma_TurmasturmaId",
                        column: x => x.TurmasturmaId,
                        principalTable: "Turma",
                        principalColumn: "turma_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ciclo",
                columns: table => new
                {
                    id_ciclo = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome_ciclo = table.Column<string>(type: "text", nullable: false),
                    data_inicio = table.Column<DateOnly>(type: "date", nullable: false),
                    data_fim = table.Column<DateOnly>(type: "date", nullable: false),
                    peso_nota = table.Column<float>(type: "real", nullable: false),
                    turma_id = table.Column<long>(type: "bigint", nullable: false),
                    alunoId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciclo", x => x.id_ciclo);
                    table.ForeignKey(
                        name: "FK_Ciclo_Aluno_alunoId",
                        column: x => x.alunoId,
                        principalTable: "Aluno",
                        principalColumn: "aluno_id");
                    table.ForeignKey(
                        name: "FK_Ciclo_Turma_turma_id",
                        column: x => x.turma_id,
                        principalTable: "Turma",
                        principalColumn: "turma_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Atividade",
                columns: table => new
                {
                    id_atividade = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome_atividade = table.Column<string>(type: "text", nullable: false),
                    nota_atividade = table.Column<float>(type: "real", nullable: false),
                    aluno_id = table.Column<long>(type: "bigint", nullable: false),
                    ciclo_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atividade", x => x.id_atividade);
                    table.ForeignKey(
                        name: "FK_Atividade_Aluno_aluno_id",
                        column: x => x.aluno_id,
                        principalTable: "Aluno",
                        principalColumn: "aluno_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Atividade_Ciclo_ciclo_id",
                        column: x => x.ciclo_id,
                        principalTable: "Ciclo",
                        principalColumn: "id_ciclo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_grupoId",
                table: "Aluno",
                column: "grupoId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunoTurma_TurmasturmaId",
                table: "AlunoTurma",
                column: "TurmasturmaId");

            migrationBuilder.CreateIndex(
                name: "IX_Atividade_aluno_id",
                table: "Atividade",
                column: "aluno_id");

            migrationBuilder.CreateIndex(
                name: "IX_Atividade_ciclo_id",
                table: "Atividade",
                column: "ciclo_id");

            migrationBuilder.CreateIndex(
                name: "IX_Ciclo_alunoId",
                table: "Ciclo",
                column: "alunoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ciclo_turma_id",
                table: "Ciclo",
                column: "turma_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunoTurma");

            migrationBuilder.DropTable(
                name: "Atividade");

            migrationBuilder.DropTable(
                name: "Ciclo");

            migrationBuilder.DropTable(
                name: "Aluno");

            migrationBuilder.DropTable(
                name: "Turma");

            migrationBuilder.DropTable(
                name: "Grupo");
        }
    }
}
