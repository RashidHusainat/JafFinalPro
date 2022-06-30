using Microsoft.EntityFrameworkCore.Migrations;

namespace JafFinalPro.Migrations
{
    public partial class _3thMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SliderImg",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SliderImg",
                table: "Sliders");
        }
    }
}
