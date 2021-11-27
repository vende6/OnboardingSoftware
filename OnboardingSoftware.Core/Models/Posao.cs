using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingSoftware.Core.Models
{
    public class Posao
    {
        public Posao()
        {
            this.AplikantPosao = new HashSet<AplikantPosao>();
        }
        public int ID { get; set; }
        public string Naziv { get; set; }
        public string Tip { get; set; }
        public string Kategorija { get; set; }
        public string Opis { get; set; }
        public int LokacijaID { get; set; }
        public Lokacija Lokacija { get; set; }
        public int TestID { get; set; }
        public virtual Test Test { get; set; }
        public virtual ICollection<AplikantPosao> AplikantPosao { get; set; }

    }
}
