using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KareAjansi.DAL.Migrations
{
    /// <inheritdoc />
    public partial class instance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategoriler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KategoriThree = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Fiyat = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedComputerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedComputerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoriler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organizasyonlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaslangicTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BitisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sehir = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Firma = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GunSayisi = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedComputerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedComputerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizasyonlar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mankenler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tel1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tel2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AyakkabiNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Beden = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kilo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SacRengi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GozRengi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SehirDisiCalisabilmeDurumu = table.Column<bool>(type: "bit", nullable: false),
                    Ehliyet = table.Column<bool>(type: "bit", nullable: false),
                    YabanciDil = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ozellik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cinsiyet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KategoriId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedComputerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedComputerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mankenler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mankenler_Kategoriler_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "Kategoriler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Odemeler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ucret = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OdemeTipi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GunlukUcret = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    KonaklamaUcreti = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    YemekUcreti = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MankenId = table.Column<int>(type: "int", nullable: false),
                    OrganizasyonId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedComputerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedComputerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odemeler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Odemeler_Mankenler_MankenId",
                        column: x => x.MankenId,
                        principalTable: "Mankenler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Odemeler_Organizasyonlar_OrganizasyonId",
                        column: x => x.OrganizasyonId,
                        principalTable: "Organizasyonlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrganizasyonMankenler",
                columns: table => new
                {
                    OrganizasyonId = table.Column<int>(type: "int", nullable: false),
                    MankenId = table.Column<int>(type: "int", nullable: false),
                    KatilmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedComputerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedComputerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizasyonMankenler", x => new { x.OrganizasyonId, x.MankenId });
                    table.ForeignKey(
                        name: "FK_OrganizasyonMankenler_Mankenler_MankenId",
                        column: x => x.MankenId,
                        principalTable: "Mankenler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganizasyonMankenler_Organizasyonlar_OrganizasyonId",
                        column: x => x.OrganizasyonId,
                        principalTable: "Organizasyonlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Resimler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResimData = table.Column<int>(type: "int", nullable: false),
                    MankenId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedComputerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedComputerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resimler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resimler_Mankenler_MankenId",
                        column: x => x.MankenId,
                        principalTable: "Mankenler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Yorumlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Yazari = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Yorumu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MankenId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedComputerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedComputerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yorumlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Yorumlar_Mankenler_MankenId",
                        column: x => x.MankenId,
                        principalTable: "Mankenler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Kategoriler",
                columns: new[] { "Id", "Ad", "CreateDate", "CreatedComputerName", "CreatedIpAddress", "Fiyat", "KategoriThree", "Status", "UpdateDate", "UpdatedComputerName", "UpdatedIpAddress" },
                values: new object[,]
                {
                    { 1, "Kategori1", null, null, null, 40, 0m, 0, null, null, null },
                    { 2, "Kategori2", null, null, null, 100, 0m, 0, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Organizasyonlar",
                columns: new[] { "Id", "Ad", "BaslangicTarihi", "BitisTarihi", "CreateDate", "CreatedComputerName", "CreatedIpAddress", "Firma", "GunSayisi", "Sehir", "Status", "UpdateDate", "UpdatedComputerName", "UpdatedIpAddress" },
                values: new object[] { 1, "Ornek Organizasyon", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Ornek Firma", 7, "İstanbul", 0, null, null, null });

            migrationBuilder.InsertData(
                table: "Mankenler",
                columns: new[] { "Id", "Ad", "Adres", "AyakkabiNo", "Beden", "Cinsiyet", "CreateDate", "CreatedComputerName", "CreatedIpAddress", "Ehliyet", "GozRengi", "KategoriId", "Kilo", "Ozellik", "SacRengi", "SehirDisiCalisabilmeDurumu", "Soyad", "Status", "Tel1", "Tel2", "UpdateDate", "UpdatedComputerName", "UpdatedIpAddress", "YabanciDil" },
                values: new object[] { 1, "Emre", "Ornek Adres", "42", "Medium", "Bay", null, null, null, true, "Kahverengi", 1, "65", "Ornek Ozellik", "Siyah", true, "Bilge", 0, "555-555-5555", "555-555-5556", null, null, null, "İngilizce" });

            migrationBuilder.InsertData(
                table: "OrganizasyonMankenler",
                columns: new[] { "MankenId", "OrganizasyonId", "CreateDate", "CreatedComputerName", "CreatedIpAddress", "Id", "KatilmaTarihi", "Status", "UpdateDate", "UpdatedComputerName", "UpdatedIpAddress" },
                values: new object[] { 1, 1, null, null, null, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Mankenler_KategoriId",
                table: "Mankenler",
                column: "KategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_Odemeler_MankenId",
                table: "Odemeler",
                column: "MankenId");

            migrationBuilder.CreateIndex(
                name: "IX_Odemeler_OrganizasyonId",
                table: "Odemeler",
                column: "OrganizasyonId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizasyonMankenler_MankenId",
                table: "OrganizasyonMankenler",
                column: "MankenId");

            migrationBuilder.CreateIndex(
                name: "IX_Resimler_MankenId",
                table: "Resimler",
                column: "MankenId");

            migrationBuilder.CreateIndex(
                name: "IX_Yorumlar_MankenId",
                table: "Yorumlar",
                column: "MankenId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Odemeler");

            migrationBuilder.DropTable(
                name: "OrganizasyonMankenler");

            migrationBuilder.DropTable(
                name: "Resimler");

            migrationBuilder.DropTable(
                name: "Yorumlar");

            migrationBuilder.DropTable(
                name: "Organizasyonlar");

            migrationBuilder.DropTable(
                name: "Mankenler");

            migrationBuilder.DropTable(
                name: "Kategoriler");
        }
    }
}
