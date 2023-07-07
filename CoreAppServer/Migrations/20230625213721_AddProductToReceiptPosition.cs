using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API.Migrations
{
    public partial class AddProductToReceiptPosition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ReceiptPosition",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductProperties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Width = table.Column<string>(type: "text", nullable: true),
                    Height = table.Column<string>(type: "text", nullable: true),
                    Depth = table.Column<string>(type: "text", nullable: true),
                    Color = table.Column<string>(type: "text", nullable: true),
                    Shape = table.Column<string>(type: "text", nullable: true),
                    Purpose = table.Column<string>(type: "text", nullable: true),
                    SwitchType = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProperties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ProductPropertiesId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_ProductProperties_ProductPropertiesId",
                        column: x => x.ProductPropertiesId,
                        principalTable: "ProductProperties",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 161, 157, 209, 66, 213, 154, 95, 201, 236, 61, 163, 240, 90, 101, 97, 218, 168, 84, 81, 146, 162, 230, 146, 107, 142, 91, 73, 17, 147, 88, 183, 169, 17, 249, 42, 27, 214, 68, 166, 66, 150, 0, 219, 195, 10, 67, 152, 173, 204, 172, 107, 210, 149, 229, 148, 2, 151, 112, 107, 229, 205, 66, 70, 34 }, new byte[] { 248, 173, 138, 235, 35, 52, 98, 19, 139, 119, 154, 195, 203, 158, 142, 175, 175, 9, 100, 5, 197, 157, 209, 184, 133, 137, 95, 244, 147, 17, 137, 151, 126, 234, 162, 163, 113, 124, 48, 216, 150, 146, 194, 43, 63, 93, 104, 246, 24, 114, 198, 59, 91, 253, 172, 125, 143, 164, 77, 138, 78, 183, 157, 56, 62, 229, 180, 171, 154, 161, 130, 237, 213, 173, 225, 90, 24, 96, 13, 184, 74, 99, 146, 190, 127, 9, 214, 23, 91, 74, 196, 253, 118, 119, 254, 53, 185, 112, 163, 24, 247, 212, 33, 144, 74, 202, 234, 32, 51, 3, 255, 11, 62, 33, 20, 37, 234, 169, 114, 194, 235, 129, 176, 100, 90, 234, 18, 233 } });

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptPosition_ProductId",
                table: "ReceiptPosition",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductPropertiesId",
                table: "Product",
                column: "ProductPropertiesId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptPosition_Product_ProductId",
                table: "ReceiptPosition",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptPosition_Product_ProductId",
                table: "ReceiptPosition");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "ProductProperties");

            migrationBuilder.DropIndex(
                name: "IX_ReceiptPosition_ProductId",
                table: "ReceiptPosition");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ReceiptPosition");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 248, 218, 153, 42, 97, 46, 20, 52, 96, 88, 17, 103, 85, 165, 233, 148, 185, 89, 178, 79, 16, 133, 48, 136, 161, 79, 199, 253, 22, 114, 151, 216, 218, 210, 200, 193, 158, 78, 38, 253, 188, 205, 236, 191, 94, 146, 13, 1, 244, 9, 215, 45, 73, 74, 156, 161, 123, 88, 20, 20, 208, 4, 227, 233 }, new byte[] { 159, 128, 196, 120, 66, 39, 247, 211, 178, 60, 22, 241, 112, 204, 224, 228, 155, 50, 200, 157, 26, 54, 141, 64, 185, 188, 32, 104, 220, 192, 221, 150, 159, 163, 43, 36, 134, 217, 248, 4, 19, 32, 176, 251, 35, 117, 9, 102, 20, 61, 78, 9, 142, 207, 56, 119, 184, 185, 194, 105, 139, 151, 118, 78, 126, 140, 122, 216, 223, 181, 30, 13, 208, 46, 91, 170, 105, 191, 175, 103, 243, 31, 47, 239, 129, 43, 100, 51, 52, 21, 250, 231, 148, 128, 86, 11, 215, 247, 221, 107, 124, 167, 178, 21, 117, 52, 21, 174, 117, 121, 105, 176, 50, 16, 20, 81, 23, 21, 145, 80, 253, 26, 19, 206, 91, 183, 78, 64 } });
        }
    }
}
