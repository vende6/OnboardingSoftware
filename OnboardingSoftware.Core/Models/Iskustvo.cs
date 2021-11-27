using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingSoftware.Core.Models
{
    public class Iskustvo
    {
        public Iskustvo()
        {
            this.AplikantIskustvo = new HashSet<AplikantIskustvo>();
        }
        public int ID { get; set; }
        public string RadnaPozicija { get; set; }
        public string TipUgovora { get; set; }
        public string NazivKompanije { get; set; }
        public string LokacijaPozicije { get; set; }
        public string OpisPozicije { get; set; }
        public DateTime DatumPocetka { get; set; }
        public DateTime DatumZavrsetka { get; set; }
        public bool JeTrenutnoZaposlen { get; set; }
        public byte[] Dokument { get; set; }
        public virtual ICollection<AplikantIskustvo> AplikantIskustvo { get; set; }
    }
}
