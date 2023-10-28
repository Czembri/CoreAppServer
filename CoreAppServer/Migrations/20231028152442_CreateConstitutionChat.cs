using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API.Migrations
{
    public partial class CreateConstitutionChat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConstitutionChat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ResponsesAndQuestions = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConstitutionChat", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 33, 95, 116, 14, 49, 110, 222, 234, 79, 63, 218, 36, 87, 201, 65, 253, 240, 149, 35, 252, 43, 244, 3, 236, 187, 53, 76, 14, 214, 36, 249, 181, 163, 172, 123, 135, 82, 22, 17, 73, 128, 56, 105, 130, 93, 111, 189, 47, 93, 142, 246, 26, 24, 203, 225, 166, 4, 248, 127, 76, 2, 103, 13, 176 }, new byte[] { 235, 101, 187, 177, 199, 186, 244, 168, 138, 23, 63, 254, 13, 242, 88, 97, 239, 7, 127, 83, 196, 220, 232, 60, 74, 164, 20, 125, 199, 213, 7, 24, 75, 195, 160, 251, 87, 241, 163, 189, 79, 131, 173, 137, 254, 203, 167, 183, 78, 100, 160, 57, 86, 63, 55, 81, 28, 176, 198, 14, 71, 156, 173, 140, 136, 126, 82, 18, 250, 211, 111, 140, 40, 189, 22, 163, 235, 66, 162, 22, 125, 115, 247, 65, 202, 61, 19, 168, 209, 102, 19, 22, 51, 207, 156, 128, 32, 74, 134, 51, 241, 211, 162, 148, 81, 38, 214, 144, 153, 254, 190, 80, 122, 18, 47, 114, 53, 18, 63, 114, 140, 231, 95, 68, 119, 119, 17, 215 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConstitutionChat");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 141, 232, 96, 112, 120, 122, 129, 62, 217, 199, 196, 145, 32, 84, 179, 7, 176, 139, 11, 108, 219, 61, 34, 63, 223, 75, 130, 211, 95, 229, 185, 1, 141, 76, 142, 111, 230, 46, 39, 84, 152, 124, 182, 188, 96, 116, 181, 7, 144, 79, 129, 50, 63, 220, 149, 125, 120, 195, 1, 247, 24, 20, 179, 193 }, new byte[] { 233, 39, 243, 188, 60, 211, 104, 184, 60, 30, 252, 136, 158, 200, 104, 124, 33, 207, 130, 162, 10, 234, 101, 122, 215, 105, 18, 46, 227, 20, 154, 248, 164, 48, 126, 158, 214, 235, 83, 123, 174, 225, 4, 12, 200, 203, 7, 169, 50, 166, 14, 181, 245, 127, 213, 154, 127, 94, 199, 236, 48, 1, 214, 139, 210, 161, 228, 123, 114, 234, 78, 11, 133, 77, 168, 89, 152, 199, 16, 130, 31, 103, 254, 184, 117, 154, 87, 7, 38, 62, 68, 55, 120, 103, 17, 222, 74, 68, 221, 179, 255, 97, 233, 210, 183, 221, 63, 82, 113, 187, 138, 30, 167, 92, 127, 173, 235, 36, 42, 233, 163, 76, 205, 235, 103, 85, 24, 189 } });
        }
    }
}
