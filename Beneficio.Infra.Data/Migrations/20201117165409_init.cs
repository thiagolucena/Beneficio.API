using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Beneficio.Infra.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orgaos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orgaos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Servidores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Endereco = table.Column<string>(type: "TEXT", nullable: true),
                    Cpf = table.Column<string>(type: "TEXT", nullable: true),
                    Matricula = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servidores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Setores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BeneficioServidores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ServidorId = table.Column<int>(type: "INTEGER", nullable: false),
                    OrgaoId = table.Column<int>(type: "INTEGER", nullable: false),
                    SetorId = table.Column<int>(type: "INTEGER", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeneficioServidores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BeneficioServidores_Orgaos_OrgaoId",
                        column: x => x.OrgaoId,
                        principalTable: "Orgaos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BeneficioServidores_Servidores_ServidorId",
                        column: x => x.ServidorId,
                        principalTable: "Servidores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BeneficioServidores_Setores_SetorId",
                        column: x => x.SetorId,
                        principalTable: "Setores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnexoBeneficios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BeneficioId = table.Column<int>(type: "INTEGER", nullable: false),
                    UrlAnexo = table.Column<string>(type: "TEXT", nullable: true),
                    CategoriaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnexoBeneficios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnexoBeneficios_BeneficioServidores_BeneficioId",
                        column: x => x.BeneficioId,
                        principalTable: "BeneficioServidores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnexoBeneficios_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovimentacaoBeneficios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BeneficioId = table.Column<int>(type: "INTEGER", nullable: false),
                    DataTramitacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SetorOrigemId = table.Column<int>(type: "INTEGER", nullable: false),
                    SetorDestinoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimentacaoBeneficios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovimentacaoBeneficios_BeneficioServidores_BeneficioId",
                        column: x => x.BeneficioId,
                        principalTable: "BeneficioServidores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovimentacaoBeneficios_Setores_SetorDestinoId",
                        column: x => x.SetorDestinoId,
                        principalTable: "Setores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovimentacaoBeneficios_Setores_SetorOrigemId",
                        column: x => x.SetorOrigemId,
                        principalTable: "Setores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnexoBeneficios_BeneficioId",
                table: "AnexoBeneficios",
                column: "BeneficioId");

            migrationBuilder.CreateIndex(
                name: "IX_AnexoBeneficios_CategoriaId",
                table: "AnexoBeneficios",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_BeneficioServidores_OrgaoId",
                table: "BeneficioServidores",
                column: "OrgaoId");

            migrationBuilder.CreateIndex(
                name: "IX_BeneficioServidores_ServidorId",
                table: "BeneficioServidores",
                column: "ServidorId");

            migrationBuilder.CreateIndex(
                name: "IX_BeneficioServidores_SetorId",
                table: "BeneficioServidores",
                column: "SetorId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimentacaoBeneficios_BeneficioId",
                table: "MovimentacaoBeneficios",
                column: "BeneficioId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimentacaoBeneficios_SetorDestinoId",
                table: "MovimentacaoBeneficios",
                column: "SetorDestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimentacaoBeneficios_SetorOrigemId",
                table: "MovimentacaoBeneficios",
                column: "SetorOrigemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnexoBeneficios");

            migrationBuilder.DropTable(
                name: "MovimentacaoBeneficios");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "BeneficioServidores");

            migrationBuilder.DropTable(
                name: "Orgaos");

            migrationBuilder.DropTable(
                name: "Servidores");

            migrationBuilder.DropTable(
                name: "Setores");
        }
    }
}
