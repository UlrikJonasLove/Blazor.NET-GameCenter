using Microsoft.EntityFrameworkCore.Migrations;

namespace gamecenter.Server.Migrations
{
    public partial class AddAdminRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO AspNetRoles (Id, [Name], NormalizedName)
                                 VALUES('a31e3c37-9f82-4aa2-b15f-a1322996c8a3', 'Admin', 'Admin')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
