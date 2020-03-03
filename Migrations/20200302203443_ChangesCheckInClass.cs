using Microsoft.EntityFrameworkCore.Migrations;

namespace sdg_api.Migrations
{
    public partial class ChangesCheckInClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Input",
                table: "CheckIns");

            migrationBuilder.DropColumn(
                name: "Output",
                table: "CheckIns");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CheckIns",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "CheckIns");

            migrationBuilder.AddColumn<string>(
                name: "Input",
                table: "CheckIns",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Output",
                table: "CheckIns",
                type: "text",
                nullable: true);
        }
    }
}
