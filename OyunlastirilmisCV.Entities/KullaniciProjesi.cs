using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OyunlastirilmisCV.Entities
{
    public class KullaniciProjesi
    {

        public int KullaniciId { get; set; }
        public Kullanici Kullanici { get; set; }

        public int ProjeId { get; set; }
        public Proje Proje { get; set; }
    }
}

