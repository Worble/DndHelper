using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DndDmHelperData.Migrations
{
    public partial class added_base_stats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaseStats",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Default = table.Column<bool>(type: "bool", nullable: false),
                    EditedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseStats", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GameCharacterBaseStats",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    BaseStatID = table.Column<int>(type: "int4", nullable: false),
                    CharacterID = table.Column<int>(type: "int4", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    EditedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    Value = table.Column<int>(type: "int4", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameCharacterBaseStats", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GameCharacterBaseStats_BaseStats_BaseStatID",
                        column: x => x.BaseStatID,
                        principalTable: "BaseStats",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameCharacterBaseStats_GameCharacters_CharacterID",
                        column: x => x.CharacterID,
                        principalTable: "GameCharacters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TemplateCharacterBaseStats",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    BaseStatID = table.Column<int>(type: "int4", nullable: false),
                    CharacterID = table.Column<int>(type: "int4", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    EditedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    Value = table.Column<int>(type: "int4", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateCharacterBaseStats", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TemplateCharacterBaseStats_BaseStats_BaseStatID",
                        column: x => x.BaseStatID,
                        principalTable: "BaseStats",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TemplateCharacterBaseStats_TemplateCharacters_CharacterID",
                        column: x => x.CharacterID,
                        principalTable: "TemplateCharacters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameCharacterBaseStats_BaseStatID",
                table: "GameCharacterBaseStats",
                column: "BaseStatID");

            migrationBuilder.CreateIndex(
                name: "IX_GameCharacterBaseStats_CharacterID",
                table: "GameCharacterBaseStats",
                column: "CharacterID");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateCharacterBaseStats_BaseStatID",
                table: "TemplateCharacterBaseStats",
                column: "BaseStatID");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateCharacterBaseStats_CharacterID",
                table: "TemplateCharacterBaseStats",
                column: "CharacterID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameCharacterBaseStats");

            migrationBuilder.DropTable(
                name: "TemplateCharacterBaseStats");

            migrationBuilder.DropTable(
                name: "BaseStats");
        }
    }
}
