using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Data.Migrations
{
    public partial class fix_constraint_nhanVienwithHoadon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoaDons_NhanViens_IdVoucher",
                table: "HoaDons");

            migrationBuilder.AlterColumn<string>(
                name: "Ten",
                table: "MauSacs",
                type: "nvarchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_IdNv",
                table: "HoaDons",
                column: "IdNv");

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDons_NhanViens_IdNv",
                table: "HoaDons",
                column: "IdNv",
                principalTable: "NhanViens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoaDons_NhanViens_IdNv",
                table: "HoaDons");

            migrationBuilder.DropIndex(
                name: "IX_HoaDons_IdNv",
                table: "HoaDons");

            migrationBuilder.AlterColumn<string>(
                name: "Ten",
                table: "MauSacs",
                type: "varchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDons_NhanViens_IdVoucher",
                table: "HoaDons",
                column: "IdVoucher",
                principalTable: "NhanViens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
