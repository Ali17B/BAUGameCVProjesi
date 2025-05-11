using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace OyunlastirilmisCV.Entities
{
    public class Proje
    {
        public int Id { get; set; }

        [Required]
        public string ProjeAdi { get; set; }

        public string Aciklama { get; set; }

        public Zorluk ZorlukSeviyesi { get; set; }

        public int KullaniciId { get; set; }
        public Kullanici Kullanici { get; set; }

        public ICollection<KullaniciProjesi> KullaniciProjeleri { get; set; }

    }
}

