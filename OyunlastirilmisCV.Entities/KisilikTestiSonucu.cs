using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OyunlastirilmisCV.Entities
{
    public class KisilikTestiSonucu
    {
        public int Id { get; set; }

        public int KullaniciId { get; set; }
        public Kullanici Kullanici { get; set; }

        public string Renk { get; set; } //kırmızı, mavi yeşil, sarı
        public DateTime Tarih { get; set; }
    }
}
