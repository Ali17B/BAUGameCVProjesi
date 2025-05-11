using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OyunlastirilmisCV.Entities
{
    public class KullaniciRozeti
    {
        public int Id { get; set; }

        public int KullaniciId { get; set; }
        public Kullanici Kullanici { get; set; }

        public int RozetId { get; set; }
        public Rozet Rozet { get; set; }

        public DateTime KazanmaTarihi { get; set; }
    }
}
