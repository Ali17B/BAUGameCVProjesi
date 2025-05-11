using System.ComponentModel.DataAnnotations;
using OyunlastirilmisCV.Entities;

namespace OyunlastirilmisCV.Models
{
    public class ProjeEkleModeli
    {
        [Required(ErrorMessage = "Proje adı zorunludur.")]
        public string ProjeAdi { get; set; }

        public string Aciklama { get; set; }

        [Required(ErrorMessage = "Zorluk seviyesi seçiniz.")]
        public Zorluk ZorlukSeviyesi { get; set; }
    }
}
