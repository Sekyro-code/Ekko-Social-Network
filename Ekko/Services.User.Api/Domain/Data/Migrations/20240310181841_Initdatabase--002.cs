using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Services.User.Api.Domain.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initdatabase002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_US.Invitation_US.Users_ReceiverId",
                table: "US.Invitation");

            migrationBuilder.DropForeignKey(
                name: "FK_US.Invitation_US.Users_SenderId",
                table: "US.Invitation");

            migrationBuilder.DropForeignKey(
                name: "FK_US.Logins_US.Users_UserId",
                table: "US.Logins");

            migrationBuilder.DropForeignKey(
                name: "FK_US.Token_US.Users_UserId",
                table: "US.Token");

            migrationBuilder.DropForeignKey(
                name: "FK_US.UserClaim_US.Users_UserId",
                table: "US.UserClaim");

            migrationBuilder.DropForeignKey(
                name: "FK_US.UserRelation_US.Users_FriendId",
                table: "US.UserRelation");

            migrationBuilder.DropForeignKey(
                name: "FK_US.UserRelation_US.Users_UserId",
                table: "US.UserRelation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_US.Users",
                table: "US.Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_US.UserRelation",
                table: "US.UserRelation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_US.UserClaim",
                table: "US.UserClaim");

            migrationBuilder.DropPrimaryKey(
                name: "PK_US.Token",
                table: "US.Token");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Us.RoleClaim",
                table: "Us.RoleClaim");

            migrationBuilder.DropPrimaryKey(
                name: "PK_US.Logins",
                table: "US.Logins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_US.Invitation",
                table: "US.Invitation");

            migrationBuilder.RenameTable(
                name: "US.Users",
                newName: "UService.Users");

            migrationBuilder.RenameTable(
                name: "US.UserRelation",
                newName: "UService.UserRelation");

            migrationBuilder.RenameTable(
                name: "US.UserClaim",
                newName: "UService.UserClaim");

            migrationBuilder.RenameTable(
                name: "US.Token",
                newName: "UService.Token");

            migrationBuilder.RenameTable(
                name: "Us.RoleClaim",
                newName: "UService.RoleClaim");

            migrationBuilder.RenameTable(
                name: "US.Logins",
                newName: "UService.Logins");

            migrationBuilder.RenameTable(
                name: "US.Invitation",
                newName: "UService.Invitation");

            migrationBuilder.RenameIndex(
                name: "IX_US.Users_Email",
                table: "UService.Users",
                newName: "IX_UService.Users_Email");

            migrationBuilder.RenameIndex(
                name: "IX_US.UserRelation_FriendId",
                table: "UService.UserRelation",
                newName: "IX_UService.UserRelation_FriendId");

            migrationBuilder.RenameIndex(
                name: "IX_US.UserClaim_UserId",
                table: "UService.UserClaim",
                newName: "IX_UService.UserClaim_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_US.Logins_UserId",
                table: "UService.Logins",
                newName: "IX_UService.Logins_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_US.Invitation_ReceiverId",
                table: "UService.Invitation",
                newName: "IX_UService.Invitation_ReceiverId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UService.Users",
                table: "UService.Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UService.UserRelation",
                table: "UService.UserRelation",
                columns: new[] { "UserId", "FriendId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UService.UserClaim",
                table: "UService.UserClaim",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UService.Token",
                table: "UService.Token",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UService.RoleClaim",
                table: "UService.RoleClaim",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UService.Logins",
                table: "UService.Logins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UService.Invitation",
                table: "UService.Invitation",
                columns: new[] { "SenderId", "ReceiverId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UService.Invitation_UService.Users_ReceiverId",
                table: "UService.Invitation",
                column: "ReceiverId",
                principalTable: "UService.Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UService.Invitation_UService.Users_SenderId",
                table: "UService.Invitation",
                column: "SenderId",
                principalTable: "UService.Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UService.Logins_UService.Users_UserId",
                table: "UService.Logins",
                column: "UserId",
                principalTable: "UService.Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UService.Token_UService.Users_UserId",
                table: "UService.Token",
                column: "UserId",
                principalTable: "UService.Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UService.UserClaim_UService.Users_UserId",
                table: "UService.UserClaim",
                column: "UserId",
                principalTable: "UService.Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UService.UserRelation_UService.Users_FriendId",
                table: "UService.UserRelation",
                column: "FriendId",
                principalTable: "UService.Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UService.UserRelation_UService.Users_UserId",
                table: "UService.UserRelation",
                column: "UserId",
                principalTable: "UService.Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UService.Invitation_UService.Users_ReceiverId",
                table: "UService.Invitation");

            migrationBuilder.DropForeignKey(
                name: "FK_UService.Invitation_UService.Users_SenderId",
                table: "UService.Invitation");

            migrationBuilder.DropForeignKey(
                name: "FK_UService.Logins_UService.Users_UserId",
                table: "UService.Logins");

            migrationBuilder.DropForeignKey(
                name: "FK_UService.Token_UService.Users_UserId",
                table: "UService.Token");

            migrationBuilder.DropForeignKey(
                name: "FK_UService.UserClaim_UService.Users_UserId",
                table: "UService.UserClaim");

            migrationBuilder.DropForeignKey(
                name: "FK_UService.UserRelation_UService.Users_FriendId",
                table: "UService.UserRelation");

            migrationBuilder.DropForeignKey(
                name: "FK_UService.UserRelation_UService.Users_UserId",
                table: "UService.UserRelation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UService.Users",
                table: "UService.Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UService.UserRelation",
                table: "UService.UserRelation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UService.UserClaim",
                table: "UService.UserClaim");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UService.Token",
                table: "UService.Token");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UService.RoleClaim",
                table: "UService.RoleClaim");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UService.Logins",
                table: "UService.Logins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UService.Invitation",
                table: "UService.Invitation");

            migrationBuilder.RenameTable(
                name: "UService.Users",
                newName: "US.Users");

            migrationBuilder.RenameTable(
                name: "UService.UserRelation",
                newName: "US.UserRelation");

            migrationBuilder.RenameTable(
                name: "UService.UserClaim",
                newName: "US.UserClaim");

            migrationBuilder.RenameTable(
                name: "UService.Token",
                newName: "US.Token");

            migrationBuilder.RenameTable(
                name: "UService.RoleClaim",
                newName: "Us.RoleClaim");

            migrationBuilder.RenameTable(
                name: "UService.Logins",
                newName: "US.Logins");

            migrationBuilder.RenameTable(
                name: "UService.Invitation",
                newName: "US.Invitation");

            migrationBuilder.RenameIndex(
                name: "IX_UService.Users_Email",
                table: "US.Users",
                newName: "IX_US.Users_Email");

            migrationBuilder.RenameIndex(
                name: "IX_UService.UserRelation_FriendId",
                table: "US.UserRelation",
                newName: "IX_US.UserRelation_FriendId");

            migrationBuilder.RenameIndex(
                name: "IX_UService.UserClaim_UserId",
                table: "US.UserClaim",
                newName: "IX_US.UserClaim_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UService.Logins_UserId",
                table: "US.Logins",
                newName: "IX_US.Logins_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UService.Invitation_ReceiverId",
                table: "US.Invitation",
                newName: "IX_US.Invitation_ReceiverId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_US.Users",
                table: "US.Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_US.UserRelation",
                table: "US.UserRelation",
                columns: new[] { "UserId", "FriendId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_US.UserClaim",
                table: "US.UserClaim",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_US.Token",
                table: "US.Token",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Us.RoleClaim",
                table: "Us.RoleClaim",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_US.Logins",
                table: "US.Logins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_US.Invitation",
                table: "US.Invitation",
                columns: new[] { "SenderId", "ReceiverId" });

            migrationBuilder.AddForeignKey(
                name: "FK_US.Invitation_US.Users_ReceiverId",
                table: "US.Invitation",
                column: "ReceiverId",
                principalTable: "US.Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_US.Invitation_US.Users_SenderId",
                table: "US.Invitation",
                column: "SenderId",
                principalTable: "US.Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_US.Logins_US.Users_UserId",
                table: "US.Logins",
                column: "UserId",
                principalTable: "US.Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_US.Token_US.Users_UserId",
                table: "US.Token",
                column: "UserId",
                principalTable: "US.Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_US.UserClaim_US.Users_UserId",
                table: "US.UserClaim",
                column: "UserId",
                principalTable: "US.Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_US.UserRelation_US.Users_FriendId",
                table: "US.UserRelation",
                column: "FriendId",
                principalTable: "US.Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_US.UserRelation_US.Users_UserId",
                table: "US.UserRelation",
                column: "UserId",
                principalTable: "US.Users",
                principalColumn: "Id");
        }
    }
}
