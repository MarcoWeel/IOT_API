using Microsoft.EntityFrameworkCore.Migrations;

namespace IOT_ArduinoDashboard.Migrations
{
    public partial class foreignkeyadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArduinoModel_ArduinoPresetModel_PresetArduinoId",
                table: "ArduinoModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ArduinoPresetPinModel_ArduinoPresetModel_ArduinoId",
                table: "ArduinoPresetPinModel");

            migrationBuilder.DropIndex(
                name: "IX_ArduinoModel_PresetArduinoId",
                table: "ArduinoModel");

            migrationBuilder.DropColumn(
                name: "PresetArduinoId",
                table: "ArduinoModel");

            migrationBuilder.RenameColumn(
                name: "ArduinoId",
                table: "ArduinoPresetPinModel",
                newName: "PresetId");

            migrationBuilder.RenameIndex(
                name: "IX_ArduinoPresetPinModel_ArduinoId",
                table: "ArduinoPresetPinModel",
                newName: "IX_ArduinoPresetPinModel_PresetId");

            migrationBuilder.RenameColumn(
                name: "ArduinoId",
                table: "ArduinoPresetModel",
                newName: "PresetId");

            migrationBuilder.AddColumn<int>(
                name: "PinType",
                table: "ArduinoPresetPinModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PresetId",
                table: "ArduinoModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ArduinoModel_PresetId",
                table: "ArduinoModel",
                column: "PresetId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArduinoModel_ArduinoPresetModel_PresetId",
                table: "ArduinoModel",
                column: "PresetId",
                principalTable: "ArduinoPresetModel",
                principalColumn: "PresetId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArduinoPresetPinModel_ArduinoPresetModel_PresetId",
                table: "ArduinoPresetPinModel",
                column: "PresetId",
                principalTable: "ArduinoPresetModel",
                principalColumn: "PresetId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArduinoModel_ArduinoPresetModel_PresetId",
                table: "ArduinoModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ArduinoPresetPinModel_ArduinoPresetModel_PresetId",
                table: "ArduinoPresetPinModel");

            migrationBuilder.DropIndex(
                name: "IX_ArduinoModel_PresetId",
                table: "ArduinoModel");

            migrationBuilder.DropColumn(
                name: "PinType",
                table: "ArduinoPresetPinModel");

            migrationBuilder.DropColumn(
                name: "PresetId",
                table: "ArduinoModel");

            migrationBuilder.RenameColumn(
                name: "PresetId",
                table: "ArduinoPresetPinModel",
                newName: "ArduinoId");

            migrationBuilder.RenameIndex(
                name: "IX_ArduinoPresetPinModel_PresetId",
                table: "ArduinoPresetPinModel",
                newName: "IX_ArduinoPresetPinModel_ArduinoId");

            migrationBuilder.RenameColumn(
                name: "PresetId",
                table: "ArduinoPresetModel",
                newName: "ArduinoId");

            migrationBuilder.AddColumn<int>(
                name: "PresetArduinoId",
                table: "ArduinoModel",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArduinoModel_PresetArduinoId",
                table: "ArduinoModel",
                column: "PresetArduinoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArduinoModel_ArduinoPresetModel_PresetArduinoId",
                table: "ArduinoModel",
                column: "PresetArduinoId",
                principalTable: "ArduinoPresetModel",
                principalColumn: "ArduinoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArduinoPresetPinModel_ArduinoPresetModel_ArduinoId",
                table: "ArduinoPresetPinModel",
                column: "ArduinoId",
                principalTable: "ArduinoPresetModel",
                principalColumn: "ArduinoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
