﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace lab1_2.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Album",
                columns: table => new
                {
                    AlbumId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Album", x => x.AlbumId);
                });

            migrationBuilder.CreateTable(
                name: "Art",
                columns: table => new
                {
                    ArtId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    imagePath = table.Column<string>(nullable: true),
                    AlbumId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Art", x => x.ArtId);
                    table.ForeignKey(
                        name: "FK_Art_Album_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Album",
                        principalColumn: "AlbumId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Art_AlbumId",
                table: "Art",
                column: "AlbumId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Art");

            migrationBuilder.DropTable(
                name: "Album");
        }
    }
}
