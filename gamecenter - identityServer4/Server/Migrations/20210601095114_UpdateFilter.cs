using Microsoft.EntityFrameworkCore.Migrations;

namespace gamecenter.Server.Migrations
{
    public partial class UpdateFilter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "NewlyReleases",
                table: "Games",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NewlyReleases",
                table: "Games");
        }
    }
}
