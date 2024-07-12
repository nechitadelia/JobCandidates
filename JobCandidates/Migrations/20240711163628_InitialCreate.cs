using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobCandidates.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobCandidates",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StartTimeInterval = table.Column<TimeOnly>(type: "time", nullable: true),
                    EndTimeInterval = table.Column<TimeOnly>(type: "time", nullable: true),
                    LinkedInProfileURL = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    GitHubProfileURL = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TextComment = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCandidates", x => x.Email);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobCandidates");
        }
    }
}
