using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OyunlastirilmisCV.Entities
{
    public class KisilikTestiSorusu
    {
        public int Id { get; set; }
        public string Mavi { get; set; }
        public string Yesil { get; set; }
        public string Sari { get; set; }
        public string Kirmizi { get; set; }
    }
}
