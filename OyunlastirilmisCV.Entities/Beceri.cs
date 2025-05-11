using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OyunlastirilmisCV.Entities
{
    public enum Zorluk
    {
        Kolay,
        Orta,
        Zor
    }

    public class Beceri
    {
        public int Id { get; set; }

        [Required]
        public string Ad { get; set; }

        public Zorluk ZorlukSeviyesi { get; set; }

        public List<Kullanici> Kullanicilar { get; set; }
        public List<KullaniciBecerisi> KullaniciBecerileri { get; set; }

    }
}
