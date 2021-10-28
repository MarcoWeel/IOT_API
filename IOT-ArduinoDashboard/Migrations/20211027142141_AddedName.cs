using Microsoft.EntityFrameworkCore.Migrations;

namespace IOT_ArduinoDashboard.Migrations
{
    public partial class AddedName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "pinMode",
                table: "DigitalPin",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "pinMode",
                table: "AnaloguePin",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pinMode",
                table: "DigitalPin");

            migrationBuilder.DropColumn(
                name: "pinMode",
                table: "AnaloguePin");
        }
    }
}
