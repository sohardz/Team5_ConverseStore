using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Data.Migrations
{
    public partial class remove_Anhbandau_CTSP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnhBanDau",
                table: "CTSanPhams");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AnhBanDau",
                table: "CTSanPhams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "CTSanPhams",
                keyColumn: "Id",
                keyValue: new Guid("93351f9a-eb83-4bc2-969d-a46275a16c7a"),
                column: "AnhBanDau",
                value: "/AnhSanPham/2.webp");

            migrationBuilder.UpdateData(
                table: "CTSanPhams",
                keyColumn: "Id",
                keyValue: new Guid("ed52daa9-f264-44af-af2e-fcf01955f968"),
                column: "AnhBanDau",
                value: "/AnhSanPham/1.webp");
        }
    }
}
