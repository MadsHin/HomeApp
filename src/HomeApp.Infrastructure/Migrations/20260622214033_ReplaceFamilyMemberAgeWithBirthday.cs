using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ReplaceFamilyMemberAgeWithBirthday : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "FamilyMembers");

            migrationBuilder.AddColumn<DateOnly>(
                name: "Birthday",
                table: "FamilyMembers",
                type: "date",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "FamilyMembers");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "FamilyMembers",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
