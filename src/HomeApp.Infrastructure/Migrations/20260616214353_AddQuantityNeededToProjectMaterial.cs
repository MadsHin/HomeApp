using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddQuantityNeededToProjectMaterial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "HomeProjectMaterials");

            migrationBuilder.AddColumn<decimal>(
                name: "QuantityNeeded",
                table: "HomeProjectMaterials",
                type: "numeric",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuantityNeeded",
                table: "HomeProjectMaterials");

            migrationBuilder.AddColumn<string>(
                name: "Quantity",
                table: "HomeProjectMaterials",
                type: "text",
                nullable: true);
        }
    }
}
