using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Services.User.Api.Domain.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initdatabase003 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UService.Role",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UService.Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UService.UserRole",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UService.UserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UService.UserRole_UService.Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "UService.Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UService.UserRole_UService.Users_UserId",
                        column: x => x.UserId,
                        principalTable: "UService.Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UService.RoleClaim_RoleId",
                table: "UService.RoleClaim",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "UService.Role",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UService.UserRole_RoleId",
                table: "UService.UserRole",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_UService.RoleClaim_UService.Role_RoleId",
                table: "UService.RoleClaim",
                column: "RoleId",
                principalTable: "UService.Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UService.RoleClaim_UService.Role_RoleId",
                table: "UService.RoleClaim");

            migrationBuilder.DropTable(
                name: "UService.UserRole");

            migrationBuilder.DropTable(
                name: "UService.Role");

            migrationBuilder.DropIndex(
                name: "IX_UService.RoleClaim_RoleId",
                table: "UService.RoleClaim");
        }
    }
}
