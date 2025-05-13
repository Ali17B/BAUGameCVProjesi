using OyunlastirilmisCV.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OyunlastirilmisCV.Business
{
    public class KisilikTestiServisi : IKisilikTestiServisi
    {
        public string Hesapla(List<KisilikTestiCevap> cevaplar)
        {
            int mavi = 0, yesil = 0, sari = 0, kirmizi = 0;

            foreach (var c in cevaplar)
            {
                mavi += c.Mavi;
                yesil += c.Yesil;
                sari += c.Sari;
                kirmizi += c.Kirmizi;
            }

            var sonuc = new Dictionary<string, int>
        {
            { "Mavi", mavi },
            { "Yeşil", yesil },
            { "Sarı", sari },
            { "Kırmızı", kirmizi }
        };

            return sonuc.OrderByDescending(x => x.Value).First().Key;
        }
    }

}
