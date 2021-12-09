using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnboardingSoftware.Web.Models
{
    public class PosaoViewModel
    {
        public string ID { get; set; }
        public string Naziv { get; set; }
        public string Tip { get; set; }
        public string Kategorija { get; set; }
        public string Opis { get; set; }
        public string Lokacija { get; set; }
    }
}
