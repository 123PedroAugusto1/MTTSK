using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyTeamTasksRecom.Migrations
{
    public partial class NomeMigracao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    PessoaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    CriadoEm = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.PessoaId);
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    PessoaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    Cargo = table.Column<string>(nullable: true),
                    Login = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.PessoaId);
                });

            migrationBuilder.CreateTable(
                name: "Projeto",
                columns: table => new
                {
                    ProjetoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    ClientePessoaId = table.Column<int>(nullable: true),
                    CriadoEm = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projeto", x => x.ProjetoId);
                    table.ForeignKey(
                        name: "FK_Projeto_Cliente_ClientePessoaId",
                        column: x => x.ClientePessoaId,
                        principalTable: "Cliente",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tarefa",
                columns: table => new
                {
                    TarefaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Titulo = table.Column<string>(nullable: true),
                    Tipo = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Prioridade = table.Column<string>(nullable: true),
                    Resolucao = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    AssinaturaPessoaId = table.Column<int>(nullable: true),
                    RequisitantePessoaId = table.Column<int>(nullable: true),
                    ProjetoId = table.Column<int>(nullable: true),
                    CriadoEm = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarefa", x => x.TarefaId);
                    table.ForeignKey(
                        name: "FK_Tarefa_Funcionario_AssinaturaPessoaId",
                        column: x => x.AssinaturaPessoaId,
                        principalTable: "Funcionario",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tarefa_Projeto_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "Projeto",
                        principalColumn: "ProjetoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tarefa_Funcionario_RequisitantePessoaId",
                        column: x => x.RequisitantePessoaId,
                        principalTable: "Funcionario",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projeto_ClientePessoaId",
                table: "Projeto",
                column: "ClientePessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefa_AssinaturaPessoaId",
                table: "Tarefa",
                column: "AssinaturaPessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefa_ProjetoId",
                table: "Tarefa",
                column: "ProjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefa_RequisitantePessoaId",
                table: "Tarefa",
                column: "RequisitantePessoaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tarefa");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "Projeto");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
