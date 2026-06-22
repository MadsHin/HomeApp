using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddStorageLocations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Materials");

            migrationBuilder.AddColumn<Guid>(
                name: "StorageLocationId",
                table: "Tools",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StorageLocationId",
                table: "Materials",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StorageLocations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageLocations", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tools_StorageLocationId",
                table: "Tools",
                column: "StorageLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_StorageLocationId",
                table: "Materials",
                column: "StorageLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_StorageLocations_StorageLocationId",
                table: "Materials",
                column: "StorageLocationId",
                principalTable: "StorageLocations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tools_StorageLocations_StorageLocationId",
                table: "Tools",
                column: "StorageLocationId",
                principalTable: "StorageLocations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materials_StorageLocations_StorageLocationId",
                table: "Materials");

            migrationBuilder.DropForeignKey(
                name: "FK_Tools_StorageLocations_StorageLocationId",
                table: "Tools");

            migrationBuilder.DropTable(
                name: "StorageLocations");

            migrationBuilder.DropIndex(
                name: "IX_Tools_StorageLocationId",
                table: "Tools");

            migrationBuilder.DropIndex(
                name: "IX_Materials_StorageLocationId",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "StorageLocationId",
                table: "Tools");

            migrationBuilder.DropColumn(
                name: "StorageLocationId",
                table: "Materials");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Materials",
                type: "text",
                nullable: true);
        }
    }
}
