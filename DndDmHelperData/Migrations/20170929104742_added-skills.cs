using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DndDmHelperData.Migrations
{
    public partial class addedskills : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Skills",
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
                    table.PrimaryKey("PK_Skills", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GameCharacterSkills",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CharacterID = table.Column<int>(type: "int4", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    EditedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    Proficient = table.Column<bool>(type: "bool", nullable: false),
                    SkillID = table.Column<int>(type: "int4", nullable: false),
                    Value = table.Column<int>(type: "int4", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameCharacterSkills", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GameCharacterSkills_GameCharacters_CharacterID",
                        column: x => x.CharacterID,
                        principalTable: "GameCharacters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameCharacterSkills_Skills_SkillID",
                        column: x => x.SkillID,
                        principalTable: "Skills",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TemplateCharacterSkills",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CharacterID = table.Column<int>(type: "int4", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    EditedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    Proficient = table.Column<bool>(type: "bool", nullable: false),
                    SkillID = table.Column<int>(type: "int4", nullable: false),
                    Value = table.Column<int>(type: "int4", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateCharacterSkills", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TemplateCharacterSkills_TemplateCharacters_CharacterID",
                        column: x => x.CharacterID,
                        principalTable: "TemplateCharacters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TemplateCharacterSkills_Skills_SkillID",
                        column: x => x.SkillID,
                        principalTable: "Skills",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameCharacterSkills_CharacterID",
                table: "GameCharacterSkills",
                column: "CharacterID");

            migrationBuilder.CreateIndex(
                name: "IX_GameCharacterSkills_SkillID",
                table: "GameCharacterSkills",
                column: "SkillID");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateCharacterSkills_CharacterID",
                table: "TemplateCharacterSkills",
                column: "CharacterID");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateCharacterSkills_SkillID",
                table: "TemplateCharacterSkills",
                column: "SkillID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameCharacterSkills");

            migrationBuilder.DropTable(
                name: "TemplateCharacterSkills");

            migrationBuilder.DropTable(
                name: "Skills");
        }
    }
}
