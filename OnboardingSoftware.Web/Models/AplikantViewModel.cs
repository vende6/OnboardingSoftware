using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnboardingSoftware.Web.Models
{
    public class AplikantViewModel
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrojTelefona { get; set; }
        public string MjestoRodjenja { get; set; }
        public string DatumRodjenja { get; set; }
        public string Adresa { get; set; }

        public string ImePrezime => Ime + " " + Prezime; 
    }
}
