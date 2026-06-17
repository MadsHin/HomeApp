using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddIsCompletedToTimelineEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "ProjectTimelineEvents",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "ProjectTimelineEvents");
        }
    }
}
