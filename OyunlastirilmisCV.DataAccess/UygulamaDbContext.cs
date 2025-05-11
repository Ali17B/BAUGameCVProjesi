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

            base.OnModelCreating(modelBuilder);
        }


    }

}
