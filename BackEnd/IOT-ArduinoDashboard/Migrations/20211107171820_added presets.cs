using Microsoft.EntityFrameworkCore.Migrations;

namespace IOT_ArduinoDashboard.Migrations
{
    public partial class addedpresets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PresetId",
                table: "ArduinoModel",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArduinoModel_PresetId",
                table: "ArduinoModel",
                column: "PresetId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArduinoModel_ArduinoPresetModel_PresetId",
                table: "ArduinoModel",
                column: "PresetId",
                principalTable: "ArduinoPresetModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArduinoModel_ArduinoPresetModel_PresetId",
                table: "ArduinoModel");

            migrationBuilder.DropIndex(
                name: "IX_ArduinoModel_PresetId",
                table: "ArduinoModel");

            migrationBuilder.DropColumn(
                name: "PresetId",
                table: "ArduinoModel");
        }
    }
}
