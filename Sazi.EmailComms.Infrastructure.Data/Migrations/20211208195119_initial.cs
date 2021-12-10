using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sazi.EmailComms.Infrastructure.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IDNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Emails",
                columns: table => new
                {
                    EmailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FromEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emails", x => x.EmailId);
                    table.ForeignKey(
                        name: "FK_Emails_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Emails_UserId",
                table: "Emails",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Emails");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
