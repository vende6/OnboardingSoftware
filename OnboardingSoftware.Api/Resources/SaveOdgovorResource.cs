using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace OnboardingSoftware.Api.Resources
{
    public class SaveOdgovorResource
    {
        public string PonudjeniOdgovor_1 { get; set; }
        public string PonudjeniOdgovor_2 { get; set; }
        public string PonudjeniOdgovor_3 { get; set; }
        public string PonudjeniOdgovor_4 { get; set; }
        [DefaultValue("False")]
        public bool TacanOdgovor_1 { get; set; }
        [DefaultValue("False")]
        public bool TacanOdgovor_2 { get; set; }
        [DefaultValue("False")]
        public bool TacanOdgovor_3 { get; set; }
        [DefaultValue("False")]
        public bool TacanOdgovor_4 { get; set; }
        public string TekstOdgovor { get; set; }
        public int PitanjeID { get; set; }
    }
}
