using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OyunlastirilmisCV.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class IlkKurulum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Beceriler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZorlukSeviyesi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beceriler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rozetler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IkonUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rozetler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdSoyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Eposta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sinifi = table.Column<int>(type: "int", nullable: false),
                    Seviye = table.Column<int>(type: "int", nullable: false),
                    AvatarUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeceriId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kullanicilar_Beceriler_BeceriId",
                        column: x => x.BeceriId,
                        principalTable: "Beceriler",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KullaniciBecerileri",
                columns: table => new
                {
                    KullaniciId = table.Column<int>(type: "int", nullable: false),
                    BeceriId = table.Column<int>(type: "int", nullable: false),
                    Seviye = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KullaniciBecerileri", x => new { x.KullaniciId, x.BeceriId });
                    table.ForeignKey(
                        name: "FK_KullaniciBecerileri_Beceriler_BeceriId",
                        column: x => x.BeceriId,
                        principalTable: "Beceriler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KullaniciBecerileri_Kullanicilar_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanicilar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KullaniciRozetleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciId = table.Column<int>(type: "int", nullable: false),
                    RozetId = table.Column<int>(type: "int", nullable: false),
                    KazanmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KullaniciRozetleri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KullaniciRozetleri_Kullanicilar_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanicilar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KullaniciRozetleri_Rozetler_RozetId",
                        column: x => x.RozetId,
                        principalTable: "Rozetler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projeler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjeAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZorlukSeviyesi = table.Column<int>(type: "int", nullable: false),
                    KullaniciId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projeler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projeler_Kullanicilar_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanicilar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KullaniciProjeleri",
                columns: table => new
                {
                    KullaniciId = table.Column<int>(type: "int", nullable: false),
                    ProjeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KullaniciProjeleri", x => new { x.KullaniciId, x.ProjeId });
                    table.ForeignKey(
                        name: "FK_KullaniciProjeleri_Kullanicilar_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanicilar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KullaniciProjeleri_Projeler_ProjeId",
                        column: x => x.ProjeId,
                        principalTable: "Projeler",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciBecerileri_BeceriId",
                table: "KullaniciBecerileri",
                column: "BeceriId");

            migrationBuilder.CreateIndex(
                name: "IX_Kullanicilar_BeceriId",
                table: "Kullanicilar",
                column: "BeceriId");

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciProjeleri_ProjeId",
                table: "KullaniciProjeleri",
                column: "ProjeId");

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciRozetleri_KullaniciId",
                table: "KullaniciRozetleri",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciRozetleri_RozetId",
                table: "KullaniciRozetleri",
                column: "RozetId");

            migrationBuilder.CreateIndex(
                name: "IX_Projeler_KullaniciId",
                table: "Projeler",
                column: "KullaniciId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KullaniciBecerileri");

            migrationBuilder.DropTable(
                name: "KullaniciProjeleri");

            migrationBuilder.DropTable(
                name: "KullaniciRozetleri");

            migrationBuilder.DropTable(
                name: "Projeler");

            migrationBuilder.DropTable(
                name: "Rozetler");

            migrationBuilder.DropTable(
                name: "Kullanicilar");

            migrationBuilder.DropTable(
                name: "Beceriler");
        }
    }
}
