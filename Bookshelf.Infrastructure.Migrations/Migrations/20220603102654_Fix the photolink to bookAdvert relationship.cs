using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookshelf.Infrastructure.Migrations.Migrations
{
    public partial class FixthephotolinktobookAdvertrelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookAdvertId",
                table: "PhotoLinks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookAdvertId",
                table: "PhotoLinks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
