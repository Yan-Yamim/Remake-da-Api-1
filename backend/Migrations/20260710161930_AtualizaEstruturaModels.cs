using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class AtualizaEstruturaModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aluno_Grupo_grupoId",
                table: "Aluno");

            migrationBuilder.DropIndex(
                name: "IX_Aluno_grupoId",
                table: "Aluno");

            migrationBuilder.DropColumn(
                name: "grupoId",
                table: "Aluno");

            migrationBuilder.CreateTable(
                name: "AlunoGrupo",
                columns: table => new
                {
                    AlunosalunoId = table.Column<long>(type: "bigint", nullable: false),
                    GruposgrupoId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoGrupo", x => new { x.AlunosalunoId, x.GruposgrupoId });
                    table.ForeignKey(
                        name: "FK_AlunoGrupo_Aluno_AlunosalunoId",
                        column: x => x.AlunosalunoId,
                        principalTable: "Aluno",
                        principalColumn: "aluno_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunoGrupo_Grupo_GruposgrupoId",
                        column: x => x.GruposgrupoId,
                        principalTable: "Grupo",
                        principalColumn: "id_grupo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunoGrupo_GruposgrupoId",
                table: "AlunoGrupo",
                column: "GruposgrupoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunoGrupo");

            migrationBuilder.AddColumn<long>(
                name: "grupoId",
                table: "Aluno",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_grupoId",
                table: "Aluno",
                column: "grupoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Aluno_Grupo_grupoId",
                table: "Aluno",
                column: "grupoId",
                principalTable: "Grupo",
                principalColumn: "id_grupo");
        }
    }
}
