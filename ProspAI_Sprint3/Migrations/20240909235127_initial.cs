using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProspAI_Sprint3.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_Funcionario_Sprint3",
                columns: table => new
                {
                    Id_fun = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nm_fun = table.Column<string>(type: "varchar2(30)", maxLength: 30, nullable: false),
                    ds_email = table.Column<string>(type: "varchar2(50)", maxLength: 50, nullable: false),
                    ds_senha = table.Column<string>(type: "varchar2(100)", maxLength: 100, nullable: false),
                    dt_adm = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Funcionario_Sprint3", x => x.Id_fun);
                });

            migrationBuilder.CreateTable(
                name: "TB_Desempenho_Sprint3",
                columns: table => new
                {
                    Id_desem = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ds_mes = table.Column<string>(type: "varchar2(15)", maxLength: 15, nullable: false),
                    nr_reclama = table.Column<byte>(type: "number(3)", nullable: false),
                    nr_reclama_solu = table.Column<byte>(type: "number(3)", nullable: false),
                    Id_fun = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Desempenho_Sprint3", x => x.Id_desem);
                    table.ForeignKey(
                        name: "FK_TB_Desempenho_Sprint3_TB_Funcionario_Sprint3_Id_fun",
                        column: x => x.Id_fun,
                        principalTable: "TB_Funcionario_Sprint3",
                        principalColumn: "Id_fun",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_Reclamacao_Sprint3",
                columns: table => new
                {
                    Id_recla = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nm_clie = table.Column<string>(type: "varchar2(30)", maxLength: 30, nullable: false),
                    dt_recla = table.Column<DateTime>(type: "date", nullable: false),
                    og_recla = table.Column<string>(type: "varchar2(20)", maxLength: 20, nullable: false),
                    st_solu = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    as_recla = table.Column<string>(type: "varchar2(100)", maxLength: 100, nullable: false),
                    Id_fun = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Reclamacao_Sprint3", x => x.Id_recla);
                    table.ForeignKey(
                        name: "FK_TB_Reclamacao_Sprint3_TB_Funcionario_Sprint3_Id_fun",
                        column: x => x.Id_fun,
                        principalTable: "TB_Funcionario_Sprint3",
                        principalColumn: "Id_fun",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_Desempenho_Sprint3_Id_fun",
                table: "TB_Desempenho_Sprint3",
                column: "Id_fun");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Reclamacao_Sprint3_Id_fun",
                table: "TB_Reclamacao_Sprint3",
                column: "Id_fun");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_Desempenho_Sprint3");

            migrationBuilder.DropTable(
                name: "TB_Reclamacao_Sprint3");

            migrationBuilder.DropTable(
                name: "TB_Funcionario_Sprint3");
        }
    }
}
