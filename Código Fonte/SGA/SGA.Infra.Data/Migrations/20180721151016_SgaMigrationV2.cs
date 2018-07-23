using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace SGA.Infra.Repository.Migrations
{
    public partial class SgaMigrationV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                "dbo");

            migrationBuilder.CreateTable(
                "responsavel",
                schema: "dbo",
                columns: table => new
                {
                    cd_responsavel = table.Column<Guid>(nullable: false),
                    nm_responsavel = table.Column<string>("varchar(50)", maxLength: 50, nullable: false),
                    cpf_responsavel = table.Column<string>("varchar(11)", nullable: false),
                    email_responsavel = table.Column<string>("varchar(30)", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_responsavel", x => x.cd_responsavel); });

            migrationBuilder.CreateTable(
                "tipo_animal",
                schema: "dbo",
                columns: table => new
                {
                    cd_tipo_animal = table.Column<Guid>(nullable: false),
                    dc_tipo_animal = table.Column<string>("varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_tipo_animal", x => x.cd_tipo_animal); });

            migrationBuilder.CreateTable(
                "animal",
                schema: "dbo",
                columns: table => new
                {
                    cd_animal = table.Column<Guid>(nullable: false),
                    nm_animal = table.Column<string>("varchar(10)", maxLength: 10, nullable: false),
                    dc_animal = table.Column<string>("varchar(100)", maxLength: 100, nullable: false),
                    cd_tipo_animal = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_animal", x => x.cd_animal);
                    table.ForeignKey(
                        "FK_animal_tipo_animal_cd_tipo_animal",
                        x => x.cd_tipo_animal,
                        principalSchema: "dbo",
                        principalTable: "tipo_animal",
                        principalColumn: "cd_tipo_animal",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "adocao",
                schema: "dbo",
                columns: table => new
                {
                    cd_animal = table.Column<Guid>(nullable: false),
                    cd_responsavel = table.Column<Guid>(nullable: false),
                    dt_adocao = table.Column<DateTime>("datetime", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adocao", x => new { x.cd_responsavel, x.cd_animal });
                    table.UniqueConstraint("animal_unique", x => x.cd_animal);
                    table.ForeignKey(
                        "FK_adocao_animal_cd_animal",
                        x => x.cd_animal,
                        principalSchema: "dbo",
                        principalTable: "animal",
                        principalColumn: "cd_animal",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_adocao_responsavel_cd_responsavel",
                        x => x.cd_responsavel,
                        principalSchema: "dbo",
                        principalTable: "responsavel",
                        principalColumn: "cd_responsavel",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_animal_cd_tipo_animal",
                schema: "dbo",
                table: "animal",
                column: "cd_tipo_animal");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "adocao",
                "dbo");

            migrationBuilder.DropTable(
                "animal",
                "dbo");

            migrationBuilder.DropTable(
                "responsavel",
                "dbo");

            migrationBuilder.DropTable(
                "tipo_animal",
                "dbo");
        }
    }
}