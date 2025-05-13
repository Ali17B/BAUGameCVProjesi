using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OyunlastirilmisCV.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class KisilikTestiniEkledik : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KisilikTestiSonuclari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciId = table.Column<int>(type: "int", nullable: false),
                    Renk = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KisilikTestiSonuclari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KisilikTestiSonuclari_Kullanicilar_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanicilar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KisilikTestiSonuclari_KullaniciId",
                table: "KisilikTestiSonuclari",
                column: "KullaniciId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KisilikTestiSonuclari");
        }
    }
}
