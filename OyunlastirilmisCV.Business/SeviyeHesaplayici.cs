using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OyunlastirilmisCV.DataAccess;

namespace OyunlastirilmisCV.Business
{
    public class SeviyeHesaplayici : ISeviyeHesaplayici
    {
        private readonly UygulamaDbContext _context;

        public SeviyeHesaplayici(UygulamaDbContext context)
        {
            _context = context;
        }

        public int SeviyeHesapla(int kullaniciId)
        {

            var toplamPuan = _context.KullaniciBecerileri
                .Where(kb => kb.KullaniciId == kullaniciId)
                .Sum(kb => kb.Seviye);

            //her 5 puan = 1 seviye
            return toplamPuan / 5;
        }
    }
}

