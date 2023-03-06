using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Heimdall.Data.Migrations
{
    /// <inheritdoc />
    public partial class secondmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "workInstructionSets");

            migrationBuilder.CreateTable(
                name: "WorkInstructions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkInstructions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Instructions",
                columns: table => new
                {
                    InstructionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InstructionText = table.Column<string>(type: "text", nullable: false),
                    InstructionImage = table.Column<string>(type: "text", nullable: false),
                    InstructionCordinates = table.Column<string>(type: "text", nullable: false),
                    InstructionForeignKey = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructions", x => x.InstructionId);
                    table.ForeignKey(
                        name: "FK_Instructions_WorkInstructions_InstructionForeignKey",
                        column: x => x.InstructionForeignKey,
                        principalTable: "WorkInstructions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Instructions_InstructionForeignKey",
                table: "Instructions",
                column: "InstructionForeignKey");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Instructions");

            migrationBuilder.DropTable(
                name: "WorkInstructions");

            migrationBuilder.CreateTable(
                name: "workInstructionSets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: false),
                    InstructionObject = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workInstructionSets", x => x.Id);
                });
        }
    }
}
