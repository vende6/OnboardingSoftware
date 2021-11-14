using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingSoftware.Core.Models
{
    public class Aplikant
    {
        public Aplikant()
        {
            this.Vjestine = new HashSet<Vjestina>();
            this.Interesi = new HashSet<Interes>();
            this.Testovi = new HashSet<Test>();
            this.Poslovi = new HashSet<Posao>();
            this.Obrazovanje = new HashSet<Obrazovanje>();
            this.Iskustvo = new HashSet<Iskustvo>();
        }
        public int ID { get; set; }
        public string Email { get; set; }
        public string Lozinka { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrojTelefona { get; set; }
        public string MjestoRodjenja { get; set; }
        public string DatumRodjenja { get; set; }
        public string Adresa { get; set; }
        public byte[] Slika { get; set; }
        public bool JeVerifikovan { get; set; }
        public string Bio { get; set; }
        public string StatusZaposlenja { get; set; }
        public string LokacijaZaposlenja { get; set; }
        public string TrenutnaPozicija { get; set; }
        public string Industrija { get; set; }
        public virtual ICollection<Vjestina> Vjestine { get; set; }
        public virtual ICollection<Interes> Interesi { get; set; }
        public virtual ICollection<Test> Testovi { get; set; }
        public virtual ICollection<Posao> Poslovi { get; set; }
        public virtual ICollection<Obrazovanje> Obrazovanje { get; set; }
        public virtual ICollection<Iskustvo> Iskustvo { get; set; }

    }
}
