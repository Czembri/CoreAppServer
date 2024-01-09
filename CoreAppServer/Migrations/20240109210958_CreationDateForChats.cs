using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class CreationDateForChats : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "LawChat",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 173, 125, 188, 203, 99, 250, 134, 8, 238, 57, 42, 84, 158, 249, 13, 108, 2, 4, 241, 127, 231, 30, 102, 214, 220, 137, 231, 25, 61, 206, 99, 130, 56, 74, 6, 227, 158, 5, 14, 26, 200, 205, 66, 224, 96, 185, 171, 153, 246, 94, 89, 104, 80, 31, 101, 66, 72, 226, 1, 182, 209, 75, 166, 50 }, new byte[] { 117, 148, 80, 143, 116, 208, 247, 182, 154, 83, 202, 190, 38, 39, 124, 27, 90, 23, 39, 232, 242, 91, 124, 106, 2, 171, 177, 190, 62, 241, 205, 201, 160, 225, 161, 165, 213, 157, 139, 181, 235, 161, 240, 217, 132, 184, 248, 6, 45, 215, 240, 123, 83, 55, 39, 55, 133, 222, 250, 47, 167, 173, 237, 34, 151, 251, 38, 122, 106, 227, 243, 6, 45, 248, 136, 205, 139, 238, 173, 90, 160, 179, 230, 194, 117, 156, 56, 26, 52, 147, 189, 251, 108, 41, 12, 170, 228, 196, 27, 26, 255, 50, 134, 22, 234, 105, 7, 93, 254, 32, 108, 13, 67, 173, 25, 82, 112, 9, 70, 63, 78, 64, 251, 178, 102, 238, 67, 214 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "LawChat");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 118, 190, 141, 179, 230, 44, 114, 79, 21, 39, 254, 38, 173, 231, 43, 222, 26, 129, 240, 67, 126, 11, 78, 236, 6, 134, 85, 98, 155, 182, 150, 108, 247, 238, 11, 88, 152, 39, 218, 217, 4, 209, 92, 47, 32, 196, 108, 207, 9, 248, 133, 73, 148, 160, 133, 179, 153, 2, 109, 30, 210, 133, 19, 121 }, new byte[] { 233, 46, 107, 10, 154, 32, 159, 176, 104, 250, 136, 228, 152, 207, 189, 17, 172, 62, 195, 74, 154, 162, 11, 104, 155, 230, 87, 188, 138, 209, 242, 132, 68, 57, 102, 176, 104, 202, 165, 185, 14, 91, 143, 23, 19, 136, 207, 66, 6, 168, 134, 44, 251, 199, 89, 128, 25, 222, 178, 172, 33, 251, 127, 158, 172, 102, 166, 13, 118, 98, 40, 32, 100, 112, 187, 19, 43, 180, 243, 76, 71, 254, 228, 246, 38, 201, 24, 115, 21, 7, 215, 27, 139, 179, 213, 254, 179, 30, 193, 80, 25, 165, 66, 125, 156, 18, 14, 224, 64, 85, 81, 232, 213, 241, 171, 206, 31, 152, 238, 232, 196, 25, 185, 127, 107, 127, 186, 20 } });
        }
    }
}
