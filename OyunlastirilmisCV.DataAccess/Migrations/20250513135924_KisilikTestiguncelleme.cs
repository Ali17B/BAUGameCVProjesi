using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OyunlastirilmisCV.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class KisilikTestiguncelleme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KisilikRengi",
                table: "Kullanicilar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "KisilikTestiSorulari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoruMetni = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecenekA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecenekB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecenekC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecenekD = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KisilikTestiSorulari", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KisilikTestiSorulari");

            migrationBuilder.DropColumn(
                name: "KisilikRengi",
                table: "Kullanicilar");
        }
    }
}
