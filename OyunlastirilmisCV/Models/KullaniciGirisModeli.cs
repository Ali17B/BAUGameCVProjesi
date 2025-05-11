using System.ComponentModel.DataAnnotations;

namespace OyunlastirilmisCV.Models
{
    public class KullaniciGirisModeli
    {
        [Required(ErrorMessage = "E-posta adresi giriniz.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta giriniz.")]
        public string Eposta { get; set; }

        [Required(ErrorMessage = "Şifre giriniz.")]
        public string Sifre { get; set; }
    }
}
