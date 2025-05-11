using System.ComponentModel.DataAnnotations;
using OyunlastirilmisCV.Entities;

namespace OyunlastirilmisCV.Models
{
    public class BeceriEkleModeli
    {
        [Required(ErrorMessage = "Beceri adı giriniz.")]
        public string BeceriAdi { get; set; }

        [Required(ErrorMessage = "Zorluk seviyesi seçiniz.")]
        public Zorluk ZorlukSeviyesi { get; set; }

        [Range(1, 10, ErrorMessage = "Seviye 1-10 arasında olmalıdır.")]
        public int Seviye { get; set; }
    }
}
