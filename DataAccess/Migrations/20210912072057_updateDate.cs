using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class updateDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LaunchData",
                table: "Mobiles");

            migrationBuilder.AddColumn<DateTime>(
                name: "LaunchDate",
                table: "Mobiles",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LaunchDate",
                table: "Mobiles");

            migrationBuilder.AddColumn<string>(
                name: "LaunchData",
                table: "Mobiles",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
