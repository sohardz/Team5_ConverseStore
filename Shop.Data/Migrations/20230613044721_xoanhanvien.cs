using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Data.Migrations
{
    public partial class xoanhanvien : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoaDons_NhanViens_NhanVienId",
                table: "HoaDons");

            migrationBuilder.DropIndex(
                name: "IX_HoaDons_NhanVienId",
                table: "HoaDons");

            migrationBuilder.DropColumn(
                name: "NhanVienId",
                table: "HoaDons");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "NhanVienId",
                table: "HoaDons",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_NhanVienId",
                table: "HoaDons",
                column: "NhanVienId");

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDons_NhanViens_NhanVienId",
                table: "HoaDons",
                column: "NhanVienId",
                principalTable: "NhanViens",
                principalColumn: "Id");
        }
    }
}
