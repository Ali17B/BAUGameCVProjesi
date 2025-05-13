using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OyunlastirilmisCV.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class TSorulariEklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "KisilikTestiSorulari",
                columns: new[] { "Id", "Kirmizi", "Mavi", "Sari", "Yesil" },
                values: new object[,]
                {
                    { 4, "Rekabetçi", "Dikkatli", "İnandırıcı", "Kontrollü" },
                    { 5, "Becerikli", "Saygılı", "Öğretici", "Programa Bağlı" },
                    { 6, "Güç Veren", "Tedbirli", "Lider", "Halinden Memnun" },
                    { 7, "Pozitif", "Planlı", "Destekleyici", "Sabırlı" },
                    { 8, "Özgüvenli", "Düzenli", "Doğal Karizmatik", "Ağırbaşlı" },
                    { 9, "Dobra", "Ciddi", "Neşeli", "İletişimi Kuvvetli" },
                    { 10, "Otoriter", "Resmi", "İletişim Seven", "Arkadaşçıl" },
                    { 11, "Cesur", "Detaycı", "Girişken", "İş Birlikçi" },
                    { 12, "İş Güvenilir", "Sanatla İlgilenen", "Yenilikçi Fikir Sahibi", "Tutarli" },
                    { 13, "Bağımsız", "Mantıksal", "Cömert", "İlimli" },
                    { 14, "Sonuç Odaklı", "Eleştiren", "İnsancıl", "Hazır Cevap" },
                    { 15, "Harekete Geçiren", "Gerçekçi", "Sıcak Kanlı", "Arabulucu" },
                    { 16, "Azimli", "Düşünce Yoğun", "Konuşkan", "Hoşgörülü" },
                    { 17, "Girişimci", "Araştırmacı", "Hareketli", "İyi Dinleyici" },
                    { 18, "Pratik", "Sayısal", "Hayalci", "Hesaplayan" },
                    { 19, "Üretken", "Analitik", "Empati Kurabilen", "Sadık" },
                    { 20, "Hızlı", "Disiplinli", "Coşkulu", "Dengeli" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "KisilikTestiSorulari",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "KisilikTestiSorulari",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "KisilikTestiSorulari",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "KisilikTestiSorulari",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "KisilikTestiSorulari",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "KisilikTestiSorulari",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "KisilikTestiSorulari",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "KisilikTestiSorulari",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "KisilikTestiSorulari",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "KisilikTestiSorulari",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "KisilikTestiSorulari",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "KisilikTestiSorulari",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "KisilikTestiSorulari",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "KisilikTestiSorulari",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "KisilikTestiSorulari",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "KisilikTestiSorulari",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "KisilikTestiSorulari",
                keyColumn: "Id",
                keyValue: 20);
        }
    }
}
