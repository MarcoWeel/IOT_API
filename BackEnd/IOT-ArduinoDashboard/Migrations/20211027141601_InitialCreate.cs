using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IOT_ArduinoDashboard.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ArduinoModel",
                columns: table => new
                {
                    ArduinoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArduinoModel", x => x.ArduinoId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AnaloguePin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    pinString = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ArduinoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnaloguePin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnaloguePin_ArduinoModel_ArduinoId",
                        column: x => x.ArduinoId,
                        principalTable: "ArduinoModel",
                        principalColumn: "ArduinoId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DigitalPin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    pinNumber = table.Column<int>(type: "int", nullable: false),
                    ArduinoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DigitalPin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DigitalPin_ArduinoModel_ArduinoId",
                        column: x => x.ArduinoId,
                        principalTable: "ArduinoModel",
                        principalColumn: "ArduinoId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AnaloguePin_ArduinoId",
                table: "AnaloguePin",
                column: "ArduinoId");

            migrationBuilder.CreateIndex(
                name: "IX_DigitalPin_ArduinoId",
                table: "DigitalPin",
                column: "ArduinoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnaloguePin");

            migrationBuilder.DropTable(
                name: "DigitalPin");

            migrationBuilder.DropTable(
                name: "ArduinoModel");
        }
    }
}
