using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class AddUserIdsToConstitutionChat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ConstitutionChat",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 62, 24, 132, 166, 126, 130, 91, 183, 33, 51, 164, 86, 103, 223, 10, 96, 219, 188, 134, 80, 116, 242, 114, 23, 3, 188, 158, 41, 27, 243, 21, 247, 34, 204, 166, 183, 234, 0, 237, 66, 67, 129, 221, 69, 221, 50, 211, 190, 252, 87, 210, 169, 105, 103, 79, 44, 121, 151, 29, 127, 206, 150, 100, 232 }, new byte[] { 100, 35, 173, 3, 81, 193, 63, 171, 41, 49, 101, 220, 51, 179, 116, 189, 65, 205, 189, 217, 34, 146, 62, 183, 120, 239, 209, 186, 0, 179, 148, 5, 215, 120, 255, 193, 139, 86, 55, 216, 28, 160, 47, 56, 146, 172, 41, 252, 38, 34, 191, 12, 254, 151, 8, 28, 245, 199, 18, 32, 97, 73, 203, 166, 77, 205, 67, 41, 203, 248, 165, 75, 252, 236, 100, 126, 72, 184, 106, 217, 26, 58, 219, 133, 59, 35, 126, 243, 228, 34, 70, 15, 235, 91, 195, 69, 154, 113, 27, 114, 81, 42, 9, 169, 238, 139, 13, 152, 124, 169, 151, 106, 119, 10, 32, 198, 232, 174, 191, 18, 112, 90, 10, 226, 70, 251, 71, 122 } });

            migrationBuilder.CreateIndex(
                name: "IX_ConstitutionChat_UserId",
                table: "ConstitutionChat",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConstitutionChat_Users_UserId",
                table: "ConstitutionChat",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConstitutionChat_Users_UserId",
                table: "ConstitutionChat");

            migrationBuilder.DropIndex(
                name: "IX_ConstitutionChat_UserId",
                table: "ConstitutionChat");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ConstitutionChat");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 33, 95, 116, 14, 49, 110, 222, 234, 79, 63, 218, 36, 87, 201, 65, 253, 240, 149, 35, 252, 43, 244, 3, 236, 187, 53, 76, 14, 214, 36, 249, 181, 163, 172, 123, 135, 82, 22, 17, 73, 128, 56, 105, 130, 93, 111, 189, 47, 93, 142, 246, 26, 24, 203, 225, 166, 4, 248, 127, 76, 2, 103, 13, 176 }, new byte[] { 235, 101, 187, 177, 199, 186, 244, 168, 138, 23, 63, 254, 13, 242, 88, 97, 239, 7, 127, 83, 196, 220, 232, 60, 74, 164, 20, 125, 199, 213, 7, 24, 75, 195, 160, 251, 87, 241, 163, 189, 79, 131, 173, 137, 254, 203, 167, 183, 78, 100, 160, 57, 86, 63, 55, 81, 28, 176, 198, 14, 71, 156, 173, 140, 136, 126, 82, 18, 250, 211, 111, 140, 40, 189, 22, 163, 235, 66, 162, 22, 125, 115, 247, 65, 202, 61, 19, 168, 209, 102, 19, 22, 51, 207, 156, 128, 32, 74, 134, 51, 241, 211, 162, 148, 81, 38, 214, 144, 153, 254, 190, 80, 122, 18, 47, 114, 53, 18, 63, 114, 140, 231, 95, 68, 119, 119, 17, 215 } });
        }
    }
}
