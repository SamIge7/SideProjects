using Microsoft.EntityFrameworkCore.Migrations;

namespace CompetitionSchedule.Migrations
{
    public partial class EventType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventType",
                table: "RaceSchedules",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventType",
                table: "RaceSchedules");
        }
    }
}
