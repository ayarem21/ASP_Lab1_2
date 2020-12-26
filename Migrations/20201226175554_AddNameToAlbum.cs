using Microsoft.EntityFrameworkCore.Migrations;

namespace lab1_2.Migrations
{
    public partial class AddNameToAlbum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Album",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Album");
        }
    }
}
