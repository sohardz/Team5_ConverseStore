using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Data.Migrations;

public partial class fix_dbcontext : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_KhachHangs_CapBac_IdBac",
            table: "KhachHangs");

        migrationBuilder.DropPrimaryKey(
            name: "PK_CapBac",
            table: "CapBac");

        migrationBuilder.RenameTable(
            name: "CapBac",
            newName: "CapBacs");

        migrationBuilder.AddColumn<int>(
            name: "SoDiem",
            table: "KhachHangs",
            type: "int",
            nullable: false,
            defaultValue: 0);

        migrationBuilder.AddPrimaryKey(
            name: "PK_CapBacs",
            table: "CapBacs",
            column: "Id");

        migrationBuilder.AddForeignKey(
            name: "FK_KhachHangs_CapBacs_IdBac",
            table: "KhachHangs",
            column: "IdBac",
            principalTable: "CapBacs",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_KhachHangs_CapBacs_IdBac",
            table: "KhachHangs");

        migrationBuilder.DropPrimaryKey(
            name: "PK_CapBacs",
            table: "CapBacs");

        migrationBuilder.DropColumn(
            name: "SoDiem",
            table: "KhachHangs");

        migrationBuilder.RenameTable(
            name: "CapBacs",
            newName: "CapBac");

        migrationBuilder.AddPrimaryKey(
            name: "PK_CapBac",
            table: "CapBac",
            column: "Id");

        migrationBuilder.AddForeignKey(
            name: "FK_KhachHangs_CapBac_IdBac",
            table: "KhachHangs",
            column: "IdBac",
            principalTable: "CapBac",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }
}
