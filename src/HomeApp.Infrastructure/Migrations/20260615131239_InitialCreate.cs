using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FamilyMembers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyMembers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HomeProjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Budget = table.Column<decimal>(type: "numeric", nullable: true),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: true),
                    CompletedDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeProjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HouseholdTasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    DueDate = table.Column<DateOnly>(type: "date", nullable: true),
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: false),
                    Recurrence = table.Column<int>(type: "integer", nullable: false),
                    AssignedMemberId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseholdTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HouseholdTasks_FamilyMembers_AssignedMemberId",
                        column: x => x.AssignedMemberId,
                        principalTable: "FamilyMembers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HomeProjectContacts",
                columns: table => new
                {
                    HomeProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    ContactId = table.Column<Guid>(type: "uuid", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeProjectContacts", x => new { x.HomeProjectId, x.ContactId });
                    table.ForeignKey(
                        name: "FK_HomeProjectContacts_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomeProjectContacts_HomeProjects_HomeProjectId",
                        column: x => x.HomeProjectId,
                        principalTable: "HomeProjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    HomeProjectId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_HomeProjects_HomeProjectId",
                        column: x => x.HomeProjectId,
                        principalTable: "HomeProjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProgressEntries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: false),
                    HomeProjectId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgressEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgressEntries_HomeProjects_HomeProjectId",
                        column: x => x.HomeProjectId,
                        principalTable: "HomeProjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectLinks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Label = table.Column<string>(type: "text", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: false),
                    HomeProjectId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectLinks_HomeProjects_HomeProjectId",
                        column: x => x.HomeProjectId,
                        principalTable: "HomeProjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HomeProjectMaterials",
                columns: table => new
                {
                    HomeProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    MaterialId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeProjectMaterials", x => new { x.HomeProjectId, x.MaterialId });
                    table.ForeignKey(
                        name: "FK_HomeProjectMaterials_HomeProjects_HomeProjectId",
                        column: x => x.HomeProjectId,
                        principalTable: "HomeProjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomeProjectMaterials_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HomeProjectContacts_ContactId",
                table: "HomeProjectContacts",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeProjectMaterials_MaterialId",
                table: "HomeProjectMaterials",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseholdTasks_AssignedMemberId",
                table: "HouseholdTasks",
                column: "AssignedMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_HomeProjectId",
                table: "Photos",
                column: "HomeProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgressEntries_HomeProjectId",
                table: "ProgressEntries",
                column: "HomeProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectLinks_HomeProjectId",
                table: "ProjectLinks",
                column: "HomeProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HomeProjectContacts");

            migrationBuilder.DropTable(
                name: "HomeProjectMaterials");

            migrationBuilder.DropTable(
                name: "HouseholdTasks");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "ProgressEntries");

            migrationBuilder.DropTable(
                name: "ProjectLinks");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "FamilyMembers");

            migrationBuilder.DropTable(
                name: "HomeProjects");
        }
    }
}
