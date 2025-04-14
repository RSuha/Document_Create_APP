using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreateDocumentAPP_2.Migrations
{
    /// <inheritdoc />
    public partial class AddIlgiliGorselUrlToGereksinimNotu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IlgiliGorselUrl",
                table: "FonksiyonelGereksinimler");

            migrationBuilder.AlterColumn<string>(
                name: "Ad",
                table: "Sirketler",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AddColumn<string>(
                name: "IlgiliGorselUrl",
                table: "GereksinimNotlari",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IlgiliGorselUrl",
                table: "GereksinimNotlari");

            migrationBuilder.AlterColumn<string>(
                name: "Ad",
                table: "Sirketler",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "IlgiliGorselUrl",
                table: "FonksiyonelGereksinimler",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
