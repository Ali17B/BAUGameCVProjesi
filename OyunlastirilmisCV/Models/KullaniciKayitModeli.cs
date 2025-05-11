using System.ComponentModel.DataAnnotations;
using OyunlastirilmisCV.Entities;

namespace OyunlastirilmisCV.Models
{
    public class KullaniciKayitModeli
    {
        [Required(ErrorMessage = "Ad soyad boş bırakılamaz.")]
        public string AdSoyad { get; set; }

        [Required(ErrorMessage = "E-posta adresi zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta giriniz.")]
        public string Eposta { get; set; }

        [Required(ErrorMessage = "Şifre zorunludur.")]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalıdır.")]
        public string Sifre { get; set; }

        [Required(ErrorMessage = "Sınıf seçimi zorunludur.")]
        public KarakterSinifi Sinif { get; set; }
    }
}
