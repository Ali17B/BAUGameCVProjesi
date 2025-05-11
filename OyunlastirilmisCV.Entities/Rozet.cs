using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OyunlastirilmisCV.Entities
{
    public class Rozet
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string IkonUrl { get; set; }

        public ICollection<KullaniciRozeti> KullaniciRozetleri { get; set; }
    }
}
