using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OyunlastirilmisCV.Entities
{
    public class KullaniciBecerisi
    {
        public int KullaniciId { get; set; }
        public Kullanici Kullanici { get; set; }

        public int BeceriId { get; set; }
        public Beceri Beceri { get; set; }

        public int Seviye { get; set; } // 1 ilw 10 arasi
    }
}
