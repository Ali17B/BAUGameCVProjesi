using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using OyunlastirilmisCV.Entities;

namespace OyunlastirilmisCV.DataAccess
{
    public class UygulamaDbContext : DbContext
    {
        public UygulamaDbContext(DbContextOptions<UygulamaDbContext> options) : base(options) { }

        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Beceri> Beceriler { get; set; }
        public DbSet<Proje> Projeler { get; set; }
        public DbSet<KullaniciBecerisi> KullaniciBecerileri { get; set; }
        public DbSet<KullaniciProjesi> KullaniciProjeleri { get; set; }
        public DbSet<Rozet> Rozetler { get; set; }
        public DbSet<KullaniciRozeti> KullaniciRozetleri { get; set; }

        public DbSet<KisilikTestiSonucu> KisilikTestiSonuclari { get; set; }

        public DbSet<KisilikTestiSorusu> KisilikTestiSorulari { get; set; }






        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KullaniciBecerisi>()
                .HasKey(kb => new { kb.KullaniciId, kb.BeceriId });

            modelBuilder.Entity<KullaniciBecerisi>()
                .HasOne(kb => kb.Kullanici)
                .WithMany(k => k.KullaniciBecerileri)
                .HasForeignKey(kb => kb.KullaniciId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<KullaniciBecerisi>()
                .HasOne(kb => kb.Beceri)
                .WithMany(b => b.KullaniciBecerileri)
                .HasForeignKey(kb => kb.BeceriId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<KullaniciProjesi>()
                .HasKey(kp => new { kp.KullaniciId, kp.ProjeId });

            modelBuilder.Entity<KullaniciProjesi>()
                .HasOne(kp => kp.Kullanici)
                .WithMany(k => k.KullaniciProjeleri)
                .HasForeignKey(kp => kp.KullaniciId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<KullaniciProjesi>()
                .HasOne(kp => kp.Proje)
                .WithMany(p => p.KullaniciProjeleri)
                .HasForeignKey(kp => kp.ProjeId)
                .OnDelete(DeleteBehavior.NoAction); //coklu cascade sorunu çözümü 

            modelBuilder.Entity<KullaniciRozeti>()
                .HasOne(kr => kr.Kullanici)
                .WithMany(k => k.KullaniciRozetleri)
                .HasForeignKey(kr => kr.KullaniciId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<KullaniciRozeti>()
                .HasOne(kr => kr.Rozet)
                .WithMany(r => r.KullaniciRozetleri)
                .HasForeignKey(kr => kr.RozetId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<KisilikTestiSonucu>()
                .HasOne(x => x.Kullanici)
                .WithOne(k => k.KisilikTestiSonucu)
                .HasForeignKey<KisilikTestiSonucu>(x => x.KullaniciId);

            modelBuilder.Entity<KisilikTestiSorusu>().HasData(new KisilikTestiSorusu { Id = 1, Mavi = "Analitik", Yesil = "Uyumlu", Sari = "İyimser", Kirmizi = "Risk Alabilen" });
            modelBuilder.Entity<KisilikTestiSorusu>().HasData(new KisilikTestiSorusu { Id = 2, Mavi = "Ölçülü", Yesil = "Güvenilir", Sari = "Enerjik", Kirmizi = "İkna Edici" });
            modelBuilder.Entity<KisilikTestiSorusu>().HasData(new KisilikTestiSorusu { Id = 3, Mavi = "Bencil", Yesil = "Sakin", Sari = "Sosyal", Kirmizi = "Sorumluluk Alan" });
            modelBuilder.Entity<KisilikTestiSorusu>().HasData(new KisilikTestiSorusu { Id = 4, Mavi = "Dikkatli", Yesil = "Kontrollü", Sari = "İnandırıcı", Kirmizi = "Rekabetçi" });
            modelBuilder.Entity<KisilikTestiSorusu>().HasData(new KisilikTestiSorusu { Id = 5, Mavi = "Saygılı", Yesil = "Programa Bağlı", Sari = "Öğretici", Kirmizi = "Becerikli" });
            modelBuilder.Entity<KisilikTestiSorusu>().HasData(new KisilikTestiSorusu { Id = 6, Mavi = "Tedbirli", Yesil = "Halinden Memnun", Sari = "Lider", Kirmizi = "Güç Veren" });
            modelBuilder.Entity<KisilikTestiSorusu>().HasData(new KisilikTestiSorusu { Id = 7, Mavi = "Planlı", Yesil = "Sabırlı", Sari = "Destekleyici", Kirmizi = "Pozitif" });
            modelBuilder.Entity<KisilikTestiSorusu>().HasData(new KisilikTestiSorusu { Id = 8, Mavi = "Düzenli", Yesil = "Ağırbaşlı", Sari = "Doğal Karizmatik", Kirmizi = "Özgüvenli" });
            modelBuilder.Entity<KisilikTestiSorusu>().HasData(new KisilikTestiSorusu { Id = 9, Mavi = "Ciddi", Yesil = "İletişimi Kuvvetli", Sari = "Neşeli", Kirmizi = "Dobra" });
            modelBuilder.Entity<KisilikTestiSorusu>().HasData(new KisilikTestiSorusu { Id = 10, Mavi = "Resmi", Yesil = "Arkadaşçıl", Sari = "İletişim Seven", Kirmizi = "Otoriter" });
            modelBuilder.Entity<KisilikTestiSorusu>().HasData(new KisilikTestiSorusu { Id = 11, Mavi = "Detaycı", Yesil = "İş Birlikçi", Sari = "Girişken", Kirmizi = "Cesur" });
            modelBuilder.Entity<KisilikTestiSorusu>().HasData(new KisilikTestiSorusu { Id = 12, Mavi = "Sanatla İlgilenen", Yesil = "Tutarli", Sari = "Yenilikçi Fikir Sahibi", Kirmizi = "İş Güvenilir" });
            modelBuilder.Entity<KisilikTestiSorusu>().HasData(new KisilikTestiSorusu { Id = 13, Mavi = "Mantıksal", Yesil = "İlimli", Sari = "Cömert", Kirmizi = "Bağımsız" });
            modelBuilder.Entity<KisilikTestiSorusu>().HasData(new KisilikTestiSorusu { Id = 14, Mavi = "Eleştiren", Yesil = "Hazır Cevap", Sari = "İnsancıl", Kirmizi = "Sonuç Odaklı" });
            modelBuilder.Entity<KisilikTestiSorusu>().HasData(new KisilikTestiSorusu { Id = 15, Mavi = "Gerçekçi", Yesil = "Arabulucu", Sari = "Sıcak Kanlı", Kirmizi = "Harekete Geçiren" });
            modelBuilder.Entity<KisilikTestiSorusu>().HasData(new KisilikTestiSorusu { Id = 16, Mavi = "Düşünce Yoğun", Yesil = "Hoşgörülü", Sari = "Konuşkan", Kirmizi = "Azimli" });
            modelBuilder.Entity<KisilikTestiSorusu>().HasData(new KisilikTestiSorusu { Id = 17, Mavi = "Araştırmacı", Yesil = "İyi Dinleyici", Sari = "Hareketli", Kirmizi = "Girişimci" });
            modelBuilder.Entity<KisilikTestiSorusu>().HasData(new KisilikTestiSorusu { Id = 18, Mavi = "Sayısal", Yesil = "Hesaplayan", Sari = "Hayalci", Kirmizi = "Pratik" });
            modelBuilder.Entity<KisilikTestiSorusu>().HasData(new KisilikTestiSorusu { Id = 19, Mavi = "Analitik", Yesil = "Sadık", Sari = "Empati Kurabilen", Kirmizi = "Üretken" });
            modelBuilder.Entity<KisilikTestiSorusu>().HasData(new KisilikTestiSorusu { Id = 20, Mavi = "Disiplinli", Yesil = "Dengeli", Sari = "Coşkulu", Kirmizi = "Hızlı" });



            modelBuilder.Entity<Rozet>().HasData(
                new Rozet
        {
            Id = 1,
            Ad = "Usta Beceri",
            IkonUrl = "/img/rozetler/usta.png"
        }
    );



            base.OnModelCreating(modelBuilder);
        }


    }

}
