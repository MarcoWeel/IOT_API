using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IOT_ArduinoDashboard.Migrations
{
    public partial class AddedPresetpinmodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArduinoModel_ArduinoPresetModel_PresetId",
                table: "ArduinoModel");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ArduinoPresetModel",
                newName: "ArduinoId");

            migrationBuilder.RenameColumn(
                name: "PresetId",
                table: "ArduinoModel",
                newName: "PresetArduinoId");

            migrationBuilder.RenameIndex(
                name: "IX_ArduinoModel_PresetId",
                table: "ArduinoModel",
                newName: "IX_ArduinoModel_PresetArduinoId");

            migrationBuilder.CreateTable(
                name: "ArduinoPresetPinModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ArduinoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArduinoPresetPinModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArduinoPresetPinModel_ArduinoPresetModel_ArduinoId",
                        column: x => x.ArduinoId,
                        principalTable: "ArduinoPresetModel",
                        principalColumn: "ArduinoId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ArduinoPresetPinModel_ArduinoId",
                table: "ArduinoPresetPinModel",
                column: "ArduinoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArduinoModel_ArduinoPresetModel_PresetArduinoId",
                table: "ArduinoModel",
                column: "PresetArduinoId",
                principalTable: "ArduinoPresetModel",
                principalColumn: "ArduinoId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArduinoModel_ArduinoPresetModel_PresetArduinoId",
                table: "ArduinoModel");

            migrationBuilder.DropTable(
                name: "ArduinoPresetPinModel");

            migrationBuilder.RenameColumn(
                name: "ArduinoId",
                table: "ArduinoPresetModel",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PresetArduinoId",
                table: "ArduinoModel",
                newName: "PresetId");

            migrationBuilder.RenameIndex(
                name: "IX_ArduinoModel_PresetArduinoId",
                table: "ArduinoModel",
                newName: "IX_ArduinoModel_PresetId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArduinoModel_ArduinoPresetModel_PresetId",
                table: "ArduinoModel",
                column: "PresetId",
                principalTable: "ArduinoPresetModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
