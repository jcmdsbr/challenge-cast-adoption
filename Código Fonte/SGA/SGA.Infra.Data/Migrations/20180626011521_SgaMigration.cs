using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SGA.Infra.Repository.Migrations
{
    public partial class SgaMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "responsavel",
                schema: "dbo",
                columns: table => new
                {
                    cd_responsavel = table.Column<Guid>(nullable: false),
                    nm_responsavel = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    cpf_responsavel = table.Column<string>(type: "varchar(11)", nullable: false),
                    email_responsavel = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_responsavel", x => x.cd_responsavel);
                });

            migrationBuilder.CreateTable(
                name: "tipo_animal",
                schema: "dbo",
                columns: table => new
                {
                    cd_tipo_animal = table.Column<Guid>(nullable: false),
                    dc_tipo_animal = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo_animal", x => x.cd_tipo_animal);
                });

            migrationBuilder.CreateTable(
                name: "animal",
                schema: "dbo",
                columns: table => new
                {
                    cd_animal = table.Column<Guid>(nullable: false),
                    nm_animal = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    dc_animal = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    cd_tipo_animal = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_animal", x => x.cd_animal);
                    table.ForeignKey(
                        name: "FK_animal_tipo_animal_cd_tipo_animal",
                        column: x => x.cd_tipo_animal,
                        principalSchema: "dbo",
                        principalTable: "tipo_animal",
                        principalColumn: "cd_tipo_animal",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "adocao",
                schema: "dbo",
                columns: table => new
                {
                    cd_animal = table.Column<Guid>(nullable: false),
                    cd_responsavel = table.Column<Guid>(nullable: false),
                    dt_adocao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adocao", x => new { x.cd_responsavel, x.cd_animal });
                    table.UniqueConstraint("animal_unique", x => x.cd_animal);
                    table.ForeignKey(
                        name: "FK_adocao_animal_cd_animal",
                        column: x => x.cd_animal,
                        principalSchema: "dbo",
                        principalTable: "animal",
                        principalColumn: "cd_animal",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_adocao_responsavel_cd_responsavel",
                        column: x => x.cd_responsavel,
                        principalSchema: "dbo",
                        principalTable: "responsavel",
                        principalColumn: "cd_responsavel",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_animal_cd_tipo_animal",
                schema: "dbo",
                table: "animal",
                column: "cd_tipo_animal");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "adocao",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "animal",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "responsavel",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tipo_animal",
                schema: "dbo");
        }
    }
}
