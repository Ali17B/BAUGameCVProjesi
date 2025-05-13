using OyunlastirilmisCV.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OyunlastirilmisCV.Business
{
    public interface IKisilikTestiServisi
    {
        string Hesapla(List<KisilikTestiCevap> cevaplar);
    }
}
