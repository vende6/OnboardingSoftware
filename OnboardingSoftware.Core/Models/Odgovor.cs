using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingSoftware.Core.Models
{
    public class Odgovor
    {
        public int ID { get; set; }
        public string PonudjeniOdgovor_1 { get; set; }
        public string PonudjeniOdgovor_2 { get; set; }
        public string PonudjeniOdgovor_3 { get; set; }
        public string PonudjeniOdgovor_4 { get; set; }
        public bool TacanOdgovor_1 { get; set; }
        public bool TacanOdgovor_2 { get; set; }
        public bool TacanOdgovor_3 { get; set; }
        public bool TacanOdgovor_4 { get; set; }
        public string TekstOdgovor { get; set; }
        public int PitanjeID { get; set; }
        public Pitanje Pitanje { get; set; }
    }
}
