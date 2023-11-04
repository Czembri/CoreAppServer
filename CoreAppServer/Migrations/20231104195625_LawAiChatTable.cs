using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API.Migrations
{
    public partial class LawAiChatTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LawChat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Messages = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LawChat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LawChat_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 118, 190, 141, 179, 230, 44, 114, 79, 21, 39, 254, 38, 173, 231, 43, 222, 26, 129, 240, 67, 126, 11, 78, 236, 6, 134, 85, 98, 155, 182, 150, 108, 247, 238, 11, 88, 152, 39, 218, 217, 4, 209, 92, 47, 32, 196, 108, 207, 9, 248, 133, 73, 148, 160, 133, 179, 153, 2, 109, 30, 210, 133, 19, 121 }, new byte[] { 233, 46, 107, 10, 154, 32, 159, 176, 104, 250, 136, 228, 152, 207, 189, 17, 172, 62, 195, 74, 154, 162, 11, 104, 155, 230, 87, 188, 138, 209, 242, 132, 68, 57, 102, 176, 104, 202, 165, 185, 14, 91, 143, 23, 19, 136, 207, 66, 6, 168, 134, 44, 251, 199, 89, 128, 25, 222, 178, 172, 33, 251, 127, 158, 172, 102, 166, 13, 118, 98, 40, 32, 100, 112, 187, 19, 43, 180, 243, 76, 71, 254, 228, 246, 38, 201, 24, 115, 21, 7, 215, 27, 139, 179, 213, 254, 179, 30, 193, 80, 25, 165, 66, 125, 156, 18, 14, 224, 64, 85, 81, 232, 213, 241, 171, 206, 31, 152, 238, 232, 196, 25, 185, 127, 107, 127, 186, 20 } });

            migrationBuilder.CreateIndex(
                name: "IX_LawChat_UserId",
                table: "LawChat",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LawChat");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 62, 24, 132, 166, 126, 130, 91, 183, 33, 51, 164, 86, 103, 223, 10, 96, 219, 188, 134, 80, 116, 242, 114, 23, 3, 188, 158, 41, 27, 243, 21, 247, 34, 204, 166, 183, 234, 0, 237, 66, 67, 129, 221, 69, 221, 50, 211, 190, 252, 87, 210, 169, 105, 103, 79, 44, 121, 151, 29, 127, 206, 150, 100, 232 }, new byte[] { 100, 35, 173, 3, 81, 193, 63, 171, 41, 49, 101, 220, 51, 179, 116, 189, 65, 205, 189, 217, 34, 146, 62, 183, 120, 239, 209, 186, 0, 179, 148, 5, 215, 120, 255, 193, 139, 86, 55, 216, 28, 160, 47, 56, 146, 172, 41, 252, 38, 34, 191, 12, 254, 151, 8, 28, 245, 199, 18, 32, 97, 73, 203, 166, 77, 205, 67, 41, 203, 248, 165, 75, 252, 236, 100, 126, 72, 184, 106, 217, 26, 58, 219, 133, 59, 35, 126, 243, 228, 34, 70, 15, 235, 91, 195, 69, 154, 113, 27, 114, 81, 42, 9, 169, 238, 139, 13, 152, 124, 169, 151, 106, 119, 10, 32, 198, 232, 174, 191, 18, 112, 90, 10, 226, 70, 251, 71, 122 } });
        }
    }
}
