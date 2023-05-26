using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class AddCreationDateAndModificationDateToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 188, 24, 219, 140, 197, 78, 220, 104, 27, 145, 37, 233, 161, 73, 35, 28, 163, 23, 138, 190, 27, 201, 129, 50, 185, 52, 45, 92, 144, 86, 137, 20, 254, 195, 61, 156, 22, 238, 140, 94, 173, 193, 120, 10, 162, 61, 114, 212, 133, 80, 242, 52, 180, 215, 99, 58, 67, 21, 220, 68, 188, 85, 21, 97 }, new byte[] { 246, 255, 245, 179, 100, 244, 84, 163, 207, 189, 225, 202, 154, 127, 174, 35, 232, 108, 48, 94, 222, 45, 163, 224, 89, 176, 130, 48, 21, 123, 8, 173, 29, 117, 212, 212, 138, 130, 193, 197, 171, 149, 226, 204, 135, 190, 108, 144, 144, 200, 195, 216, 126, 30, 139, 134, 14, 222, 227, 135, 70, 11, 199, 12, 139, 151, 60, 204, 147, 179, 251, 76, 12, 152, 95, 207, 148, 78, 89, 153, 192, 150, 183, 94, 122, 217, 1, 191, 100, 119, 194, 31, 248, 116, 47, 109, 44, 75, 83, 149, 138, 89, 214, 120, 143, 15, 131, 163, 38, 84, 119, 241, 32, 225, 71, 251, 244, 199, 61, 189, 173, 124, 191, 1, 187, 173, 132, 197 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 42, 146, 150, 81, 100, 198, 228, 146, 34, 126, 181, 210, 148, 250, 31, 22, 178, 76, 170, 2, 21, 93, 23, 34, 28, 168, 104, 62, 139, 161, 154, 213, 150, 131, 136, 122, 205, 45, 76, 100, 183, 120, 216, 82, 231, 82, 210, 223, 218, 34, 88, 46, 67, 19, 64, 227, 155, 234, 12, 134, 225, 1, 189, 139 }, new byte[] { 212, 136, 55, 157, 234, 2, 10, 30, 201, 38, 19, 119, 200, 118, 250, 158, 149, 33, 92, 115, 57, 130, 138, 119, 239, 255, 111, 173, 55, 39, 202, 148, 155, 106, 225, 75, 160, 53, 17, 129, 228, 254, 241, 204, 119, 140, 221, 4, 87, 169, 18, 130, 224, 20, 38, 121, 253, 232, 236, 62, 248, 106, 90, 107, 220, 63, 31, 98, 240, 129, 31, 244, 255, 228, 195, 66, 128, 83, 111, 167, 66, 98, 62, 142, 108, 180, 73, 142, 37, 83, 4, 215, 192, 225, 35, 139, 119, 238, 144, 86, 12, 126, 254, 246, 209, 25, 157, 37, 236, 240, 191, 106, 49, 214, 50, 176, 59, 96, 129, 69, 19, 84, 163, 128, 230, 66, 2, 192 } });
        }
    }
}
