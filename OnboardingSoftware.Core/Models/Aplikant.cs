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
            this.AplikantVjestina = new HashSet<AplikantVjestina>();
            this.AplikantInteres = new HashSet<AplikantInteres>();
            this.AplikantTest = new HashSet<AplikantTest>();
            this.AplikantPosao = new HashSet<AplikantPosao>();
            this.AplikantObrazovanje = new HashSet<AplikantObrazovanje>();
            this.AplikantIskustvo = new HashSet<AplikantIskustvo>();
        }
        public int ID { get; set; }
        public string Email { get; set; }
        public string Lozinka { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrojTelefona { get; set; }
        public string MjestoRodjenja { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string Adresa { get; set; }
        public byte[] Slika { get; set; }
        public bool JeVerifikovan { get; set; }
        public string Bio { get; set; }
        public string StatusZaposlenja { get; set; }
        public string LokacijaZaposlenja { get; set; }
        public string TrenutnaPozicija { get; set; }
        public string Industrija { get; set; }
        public virtual ICollection<AplikantVjestina> AplikantVjestina { get; set; }
        public virtual ICollection<AplikantInteres> AplikantInteres { get; set; }
        public virtual ICollection<AplikantTest> AplikantTest { get; set; }
        public virtual ICollection<AplikantPosao> AplikantPosao { get; set; }
        public virtual ICollection<AplikantObrazovanje> AplikantObrazovanje { get; set; }
        public virtual ICollection<AplikantIskustvo> AplikantIskustvo { get; set; }
    }
}
