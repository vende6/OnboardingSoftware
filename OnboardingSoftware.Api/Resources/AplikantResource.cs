using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnboardingSoftware.Api.Resources
{
    public class AplikantResource
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrojTelefona { get; set; }
        public string MjestoRodjenja { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string Adresa { get; set; }
    }
}
