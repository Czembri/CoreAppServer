using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API.Migrations
{
    public partial class FixAndRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserInfo_Users_AppUserId",
                table: "UserInfo");

            migrationBuilder.DropIndex(
                name: "IX_UserInfo_AppUserId",
                table: "UserInfo");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "UserInfo");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UserInfo",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRole_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "PasswordSalt", "UserName" },
                values: new object[] { 1, new byte[] { 42, 146, 150, 81, 100, 198, 228, 146, 34, 126, 181, 210, 148, 250, 31, 22, 178, 76, 170, 2, 21, 93, 23, 34, 28, 168, 104, 62, 139, 161, 154, 213, 150, 131, 136, 122, 205, 45, 76, 100, 183, 120, 216, 82, 231, 82, 210, 223, 218, 34, 88, 46, 67, 19, 64, 227, 155, 234, 12, 134, 225, 1, 189, 139 }, new byte[] { 212, 136, 55, 157, 234, 2, 10, 30, 201, 38, 19, 119, 200, 118, 250, 158, 149, 33, 92, 115, 57, 130, 138, 119, 239, 255, 111, 173, 55, 39, 202, 148, 155, 106, 225, 75, 160, 53, 17, 129, 228, 254, 241, 204, 119, 140, 221, 4, 87, 169, 18, 130, 224, 20, 38, 121, 253, 232, 236, 62, 248, 106, 90, 107, 220, 63, 31, 98, 240, 129, 31, 244, 255, 228, 195, 66, 128, 83, 111, 167, 66, 98, 62, 142, 108, 180, 73, 142, 37, 83, 4, 215, 192, 225, 35, 139, 119, 238, 144, 86, 12, 126, 254, 246, 209, 25, 157, 37, 236, 240, 191, 106, 49, 214, 50, 176, 59, 96, 129, 69, 19, 84, 163, 128, 230, 66, 2, 192 }, "Admin" });

            migrationBuilder.InsertData(
                table: "UserInfo",
                columns: new[] { "Id", "Address", "City", "FirstName", "LastName", "PostalCode", "UserId" },
                values: new object[] { 1, "", "", "Admin", "", "", 1 });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "Id", "Role", "UserId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_UserInfo_UserId",
                table: "UserInfo",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId",
                table: "UserRole",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInfo_Users_UserId",
                table: "UserInfo",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserInfo_Users_UserId",
                table: "UserInfo");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropIndex(
                name: "IX_UserInfo_UserId",
                table: "UserInfo");

            migrationBuilder.DeleteData(
                table: "UserInfo",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserInfo");

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "UserInfo",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserInfo_AppUserId",
                table: "UserInfo",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInfo_Users_AppUserId",
                table: "UserInfo",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
