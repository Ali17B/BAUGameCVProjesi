using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OyunlastirilmisCV.Entities
{
    public enum KarakterSinifi
    {
        Yazilimci,
        VeriAnalisti,
        DevOps,
        Tasarimci
    }

    public class Kullanici
    {
        public int Id { get; set; }

        [Required]
        public string AdSoyad { get; set; }

        [Required]
        public string Eposta { get; set; }

        [Required]
        public string Sifre { get; set; }

        public KarakterSinifi Sinifi { get; set; }

        public int Seviye { get; set; } = 1;

        public List<KullaniciBecerisi> KullaniciBecerileri { get; set; }

        public List<Proje> Projeler { get; set; }

        public string? AvatarUrl { get; set; }
        public ICollection<KullaniciProjesi> KullaniciProjeleri { get; set; }
        public ICollection<KullaniciRozeti> KullaniciRozetleri { get; set; }



    }
}
