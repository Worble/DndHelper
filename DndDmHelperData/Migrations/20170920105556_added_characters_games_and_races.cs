using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DndDmHelperData.Migrations
{
    public partial class added_characters_games_and_races : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    EditedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Races",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    EditedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Races", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GameCharacters",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ClassID = table.Column<int>(type: "int4", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    EditedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    GameID = table.Column<int>(type: "int4", nullable: false),
                    Level = table.Column<int>(type: "int4", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    RaceID = table.Column<int>(type: "int4", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameCharacters", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GameCharacters_Classes_ClassID",
                        column: x => x.ClassID,
                        principalTable: "Classes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameCharacters_Games_GameID",
                        column: x => x.GameID,
                        principalTable: "Games",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameCharacters_Races_RaceID",
                        column: x => x.RaceID,
                        principalTable: "Races",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TemplateCharacters",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ClassID = table.Column<int>(type: "int4", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    EditedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    Level = table.Column<int>(type: "int4", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    RaceID = table.Column<int>(type: "int4", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateCharacters", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TemplateCharacters_Classes_ClassID",
                        column: x => x.ClassID,
                        principalTable: "Classes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TemplateCharacters_Races_RaceID",
                        column: x => x.RaceID,
                        principalTable: "Races",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameCharacters_ClassID",
                table: "GameCharacters",
                column: "ClassID");

            migrationBuilder.CreateIndex(
                name: "IX_GameCharacters_GameID",
                table: "GameCharacters",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_GameCharacters_RaceID",
                table: "GameCharacters",
                column: "RaceID");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateCharacters_ClassID",
                table: "TemplateCharacters",
                column: "ClassID");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateCharacters_RaceID",
                table: "TemplateCharacters",
                column: "RaceID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameCharacters");

            migrationBuilder.DropTable(
                name: "TemplateCharacters");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Races");
        }
    }
}
