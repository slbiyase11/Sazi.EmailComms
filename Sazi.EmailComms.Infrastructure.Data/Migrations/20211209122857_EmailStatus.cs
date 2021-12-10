using Microsoft.EntityFrameworkCore.Migrations;

namespace Sazi.EmailComms.Infrastructure.Data.Migrations
{
    public partial class EmailStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmailStatus",
                table: "Emails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailStatus",
                table: "Emails");
        }
    }
}
