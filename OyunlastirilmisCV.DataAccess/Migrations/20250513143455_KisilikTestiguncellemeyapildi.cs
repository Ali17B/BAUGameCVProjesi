using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OyunlastirilmisCV.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class KisilikTestiguncellemeyapildi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SecenekA",
                table: "KisilikTestiSorulari");

            migrationBuilder.RenameColumn(
                name: "SoruMetni",
                table: "KisilikTestiSorulari",
                newName: "Yesil");

            migrationBuilder.RenameColumn(
                name: "SecenekD",
                table: "KisilikTestiSorulari",
                newName: "Sari");

            migrationBuilder.RenameColumn(
                name: "SecenekC",
                table: "KisilikTestiSorulari",
                newName: "Mavi");

            migrationBuilder.RenameColumn(
                name: "SecenekB",
                table: "KisilikTestiSorulari",
                newName: "Kirmizi");

            migrationBuilder.InsertData(
                table: "KisilikTestiSorulari",
                columns: new[] { "Id", "Kirmizi", "Mavi", "Sari", "Yesil" },
                values: new object[,]
                {
                    { 1, "Risk Alabilen", "Analitik", "İyimser", "Uyumlu" },
                    { 2, "İkna Edici", "Ölçülü", "Enerjik", "Güvenilir" },
                    { 3, "Sorumluluk Alan", "Bencil", "Sosyal", "Sakin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "KisilikTestiSorulari",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "KisilikTestiSorulari",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "KisilikTestiSorulari",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "Yesil",
                table: "KisilikTestiSorulari",
                newName: "SoruMetni");

            migrationBuilder.RenameColumn(
                name: "Sari",
                table: "KisilikTestiSorulari",
                newName: "SecenekD");

            migrationBuilder.RenameColumn(
                name: "Mavi",
                table: "KisilikTestiSorulari",
                newName: "SecenekC");

            migrationBuilder.RenameColumn(
                name: "Kirmizi",
                table: "KisilikTestiSorulari",
                newName: "SecenekB");

            migrationBuilder.AddColumn<string>(
                name: "SecenekA",
                table: "KisilikTestiSorulari",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
