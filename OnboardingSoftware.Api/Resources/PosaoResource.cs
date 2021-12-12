using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnboardingSoftware.Api.Resources
{
    public class PosaoResource
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
        public string Tip { get; set; }
        public string Kategorija { get; set; }
        public string Opis { get; set; }
        public string Lokacija { get; set; }
    }
}
