using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class UpdateProoduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Product",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Product",
                type: "bytea",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 180, 186, 30, 86, 7, 178, 225, 85, 233, 206, 77, 246, 172, 198, 119, 204, 247, 173, 79, 46, 244, 37, 93, 154, 106, 138, 47, 69, 215, 62, 254, 17, 52, 28, 152, 159, 194, 18, 114, 170, 126, 61, 88, 189, 7, 125, 244, 30, 76, 84, 130, 15, 193, 30, 75, 2, 116, 0, 115, 126, 199, 181, 239, 196 }, new byte[] { 41, 198, 23, 167, 99, 155, 206, 42, 247, 59, 147, 93, 168, 15, 201, 27, 173, 111, 89, 200, 197, 165, 96, 217, 109, 58, 41, 170, 77, 209, 134, 154, 206, 119, 186, 185, 62, 244, 117, 19, 100, 150, 217, 126, 7, 192, 233, 31, 43, 164, 32, 143, 69, 142, 166, 169, 149, 70, 76, 94, 13, 56, 4, 236, 232, 49, 109, 235, 140, 53, 170, 215, 37, 43, 252, 90, 226, 237, 197, 170, 211, 83, 211, 233, 10, 187, 185, 239, 65, 41, 4, 124, 162, 224, 185, 63, 184, 125, 58, 145, 159, 125, 124, 27, 155, 134, 252, 78, 133, 122, 205, 149, 59, 119, 210, 35, 244, 57, 78, 29, 137, 8, 61, 1, 203, 23, 255, 37 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Product");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 161, 157, 209, 66, 213, 154, 95, 201, 236, 61, 163, 240, 90, 101, 97, 218, 168, 84, 81, 146, 162, 230, 146, 107, 142, 91, 73, 17, 147, 88, 183, 169, 17, 249, 42, 27, 214, 68, 166, 66, 150, 0, 219, 195, 10, 67, 152, 173, 204, 172, 107, 210, 149, 229, 148, 2, 151, 112, 107, 229, 205, 66, 70, 34 }, new byte[] { 248, 173, 138, 235, 35, 52, 98, 19, 139, 119, 154, 195, 203, 158, 142, 175, 175, 9, 100, 5, 197, 157, 209, 184, 133, 137, 95, 244, 147, 17, 137, 151, 126, 234, 162, 163, 113, 124, 48, 216, 150, 146, 194, 43, 63, 93, 104, 246, 24, 114, 198, 59, 91, 253, 172, 125, 143, 164, 77, 138, 78, 183, 157, 56, 62, 229, 180, 171, 154, 161, 130, 237, 213, 173, 225, 90, 24, 96, 13, 184, 74, 99, 146, 190, 127, 9, 214, 23, 91, 74, 196, 253, 118, 119, 254, 53, 185, 112, 163, 24, 247, 212, 33, 144, 74, 202, 234, 32, 51, 3, 255, 11, 62, 33, 20, 37, 234, 169, 114, 194, 235, 129, 176, 100, 90, 234, 18, 233 } });
        }
    }
}
