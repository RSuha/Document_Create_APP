using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreateDocumentAPP_2.Migrations
{
    /// <inheritdoc />
    public partial class InitalCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjeKategorileri",
                columns: table => new
                {
                    KategoriID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjeKategorileri", x => x.KategoriID);
                });

            migrationBuilder.CreateTable(
                name: "Sirketler",
                columns: table => new
                {
                    CompanyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    KurulusTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sirketler", x => x.CompanyID);
                });

            migrationBuilder.CreateTable(
                name: "Departmanlar",
                columns: table => new
                {
                    DepartmanID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departmanlar", x => x.DepartmanID);
                    table.ForeignKey(
                        name: "FK_Departmanlar_Sirketler_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Sirketler",
                        principalColumn: "CompanyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SifreHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rol = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<int>(type: "int", nullable: false),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SonGiris = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompanyID = table.Column<int>(type: "int", nullable: true),
                    DepartmanID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Kullanicilar_Departmanlar_DepartmanID",
                        column: x => x.DepartmanID,
                        principalTable: "Departmanlar",
                        principalColumn: "DepartmanID");
                    table.ForeignKey(
                        name: "FK_Kullanicilar_Sirketler_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Sirketler",
                        principalColumn: "CompanyID");
                });

            migrationBuilder.CreateTable(
                name: "Projeler",
                columns: table => new
                {
                    ProjeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjeAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaslangicTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BitisTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Durum = table.Column<int>(type: "int", nullable: false),
                    KategoriID = table.Column<int>(type: "int", nullable: true),
                    OlusturanID = table.Column<int>(type: "int", nullable: true),
                    CompanyID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projeler", x => x.ProjeID);
                    table.ForeignKey(
                        name: "FK_Projeler_Kullanicilar_OlusturanID",
                        column: x => x.OlusturanID,
                        principalTable: "Kullanicilar",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK_Projeler_ProjeKategorileri_KategoriID",
                        column: x => x.KategoriID,
                        principalTable: "ProjeKategorileri",
                        principalColumn: "KategoriID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projeler_Sirketler_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Sirketler",
                        principalColumn: "CompanyID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "FinansalBilgiler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjeID = table.Column<int>(type: "int", nullable: false),
                    AyrilanButce = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IlgiliIs = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinansalBilgiler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinansalBilgiler_Projeler_ProjeID",
                        column: x => x.ProjeID,
                        principalTable: "Projeler",
                        principalColumn: "ProjeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FonksiyonelGereksinimler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjeID = table.Column<int>(type: "int", nullable: false),
                    Gereklilik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Onem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IlgiliGorselUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FonksiyonelGereksinimler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FonksiyonelGereksinimler_Projeler_ProjeID",
                        column: x => x.ProjeID,
                        principalTable: "Projeler",
                        principalColumn: "ProjeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjeDetaylari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjeID = table.Column<int>(type: "int", nullable: false),
                    TeknikGereksinimler = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinansalBilgiler = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StratejikHedefler = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SonGuncelleme = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjeDetaylari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjeDetaylari_Projeler_ProjeID",
                        column: x => x.ProjeID,
                        principalTable: "Projeler",
                        principalColumn: "ProjeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjeDiyagramlari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjeID = table.Column<int>(type: "int", nullable: false),
                    DiyagramAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiyagramUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjeDiyagramlari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjeDiyagramlari_Projeler_ProjeID",
                        column: x => x.ProjeID,
                        principalTable: "Projeler",
                        principalColumn: "ProjeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjeTakimlari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjeID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    AtanmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KullaniciUserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjeTakimlari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjeTakimlari_Kullanicilar_KullaniciUserID",
                        column: x => x.KullaniciUserID,
                        principalTable: "Kullanicilar",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK_ProjeTakimlari_Kullanicilar_UserID",
                        column: x => x.UserID,
                        principalTable: "Kullanicilar",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjeTakimlari_Projeler_ProjeID",
                        column: x => x.ProjeID,
                        principalTable: "Projeler",
                        principalColumn: "ProjeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeknikGereksinimler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjeID = table.Column<int>(type: "int", nullable: false),
                    Gereksinim = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeknikGereksinimler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeknikGereksinimler_Projeler_ProjeID",
                        column: x => x.ProjeID,
                        principalTable: "Projeler",
                        principalColumn: "ProjeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GereksinimNotlari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeknikGereksinimID = table.Column<int>(type: "int", nullable: true),
                    FonksiyonelGereksinimID = table.Column<int>(type: "int", nullable: true),
                    Icerik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EklenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GereksinimNotlari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GereksinimNotlari_FonksiyonelGereksinimler_FonksiyonelGereksinimID",
                        column: x => x.FonksiyonelGereksinimID,
                        principalTable: "FonksiyonelGereksinimler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GereksinimNotlari_TeknikGereksinimler_TeknikGereksinimID",
                        column: x => x.TeknikGereksinimID,
                        principalTable: "TeknikGereksinimler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departmanlar_CompanyID",
                table: "Departmanlar",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_FinansalBilgiler_ProjeID",
                table: "FinansalBilgiler",
                column: "ProjeID");

            migrationBuilder.CreateIndex(
                name: "IX_FonksiyonelGereksinimler_ProjeID",
                table: "FonksiyonelGereksinimler",
                column: "ProjeID");

            migrationBuilder.CreateIndex(
                name: "IX_GereksinimNotlari_FonksiyonelGereksinimID",
                table: "GereksinimNotlari",
                column: "FonksiyonelGereksinimID");

            migrationBuilder.CreateIndex(
                name: "IX_GereksinimNotlari_TeknikGereksinimID",
                table: "GereksinimNotlari",
                column: "TeknikGereksinimID");

            migrationBuilder.CreateIndex(
                name: "IX_Kullanicilar_CompanyID",
                table: "Kullanicilar",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Kullanicilar_DepartmanID",
                table: "Kullanicilar",
                column: "DepartmanID");

            migrationBuilder.CreateIndex(
                name: "IX_Kullanicilar_Email",
                table: "Kullanicilar",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjeDetaylari_ProjeID",
                table: "ProjeDetaylari",
                column: "ProjeID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjeDiyagramlari_ProjeID",
                table: "ProjeDiyagramlari",
                column: "ProjeID");

            migrationBuilder.CreateIndex(
                name: "IX_Projeler_CompanyID",
                table: "Projeler",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Projeler_KategoriID",
                table: "Projeler",
                column: "KategoriID");

            migrationBuilder.CreateIndex(
                name: "IX_Projeler_OlusturanID",
                table: "Projeler",
                column: "OlusturanID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjeTakimlari_KullaniciUserID",
                table: "ProjeTakimlari",
                column: "KullaniciUserID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjeTakimlari_ProjeID",
                table: "ProjeTakimlari",
                column: "ProjeID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjeTakimlari_UserID",
                table: "ProjeTakimlari",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_TeknikGereksinimler_ProjeID",
                table: "TeknikGereksinimler",
                column: "ProjeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FinansalBilgiler");

            migrationBuilder.DropTable(
                name: "GereksinimNotlari");

            migrationBuilder.DropTable(
                name: "ProjeDetaylari");

            migrationBuilder.DropTable(
                name: "ProjeDiyagramlari");

            migrationBuilder.DropTable(
                name: "ProjeTakimlari");

            migrationBuilder.DropTable(
                name: "FonksiyonelGereksinimler");

            migrationBuilder.DropTable(
                name: "TeknikGereksinimler");

            migrationBuilder.DropTable(
                name: "Projeler");

            migrationBuilder.DropTable(
                name: "Kullanicilar");

            migrationBuilder.DropTable(
                name: "ProjeKategorileri");

            migrationBuilder.DropTable(
                name: "Departmanlar");

            migrationBuilder.DropTable(
                name: "Sirketler");
        }
    }
}
