using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreateDocumentAPP_2.Migrations
{
    /// <inheritdoc />
    public partial class AddDiyagramKategoriSystem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kategori",
                table: "ProjeDiyagramlari");

            migrationBuilder.AddColumn<int>(
                name: "KategoriID",
                table: "ProjeDiyagramlari",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DiyagramKategorileri",
                columns: table => new
                {
                    KategoriID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriAdi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiyagramKategorileri", x => x.KategoriID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjeDiyagramlari_KategoriID",
                table: "ProjeDiyagramlari",
                column: "KategoriID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjeDiyagramlari_DiyagramKategorileri_KategoriID",
                table: "ProjeDiyagramlari",
                column: "KategoriID",
                principalTable: "DiyagramKategorileri",
                principalColumn: "KategoriID",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjeDiyagramlari_DiyagramKategorileri_KategoriID",
                table: "ProjeDiyagramlari");

            migrationBuilder.DropTable(
                name: "DiyagramKategorileri");

            migrationBuilder.DropIndex(
                name: "IX_ProjeDiyagramlari_KategoriID",
                table: "ProjeDiyagramlari");

            migrationBuilder.DropColumn(
                name: "KategoriID",
                table: "ProjeDiyagramlari");

            migrationBuilder.AddColumn<string>(
                name: "Kategori",
                table: "ProjeDiyagramlari",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
