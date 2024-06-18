using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Services.User.Api.Domain.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initdatabase001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Us.RoleClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Us.RoleClaim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "US.Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    Validate = table.Column<bool>(type: "bit", nullable: false),
                    Notification = table.Column<int>(type: "int", nullable: true),
                    Biography = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Private = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_US.Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "US.Invitation",
                columns: table => new
                {
                    SenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReceiverId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_US.Invitation", x => new { x.SenderId, x.ReceiverId });
                    table.ForeignKey(
                        name: "FK_US.Invitation_US.Users_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "US.Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_US.Invitation_US.Users_SenderId",
                        column: x => x.SenderId,
                        principalTable: "US.Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "US.Logins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_US.Logins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_US.Logins_US.Users_UserId",
                        column: x => x.UserId,
                        principalTable: "US.Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "US.Token",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_US.Token", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_US.Token_US.Users_UserId",
                        column: x => x.UserId,
                        principalTable: "US.Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "US.UserClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_US.UserClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_US.UserClaim_US.Users_UserId",
                        column: x => x.UserId,
                        principalTable: "US.Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "US.UserRelation",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FriendId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_US.UserRelation", x => new { x.UserId, x.FriendId });
                    table.ForeignKey(
                        name: "FK_US.UserRelation_US.Users_FriendId",
                        column: x => x.FriendId,
                        principalTable: "US.Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_US.UserRelation_US.Users_UserId",
                        column: x => x.UserId,
                        principalTable: "US.Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_US.Invitation_ReceiverId",
                table: "US.Invitation",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_US.Logins_UserId",
                table: "US.Logins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_US.UserClaim_UserId",
                table: "US.UserClaim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_US.UserRelation_FriendId",
                table: "US.UserRelation",
                column: "FriendId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "US.Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_US.Users_Email",
                table: "US.Users",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "US.Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "US.Invitation");

            migrationBuilder.DropTable(
                name: "US.Logins");

            migrationBuilder.DropTable(
                name: "Us.RoleClaim");

            migrationBuilder.DropTable(
                name: "US.Token");

            migrationBuilder.DropTable(
                name: "US.UserClaim");

            migrationBuilder.DropTable(
                name: "US.UserRelation");

            migrationBuilder.DropTable(
                name: "US.Users");
        }
    }
}
