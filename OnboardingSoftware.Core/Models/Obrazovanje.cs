using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingSoftware.Core.Models
{
    public class Obrazovanje
    {
        public Obrazovanje()
        {
            //this.Aplikanti = new HashSet<Aplikant>();
            this.AplikantObrazovanje = new HashSet<AplikantObrazovanje>();
        }
        public int ID { get; set; }
        public string Fakultet { get; set; }
        public string Smjer { get; set; }
        public string Lokacija { get; set; }

        //public virtual ICollection<Aplikant> Aplikanti { get; set; }
        public virtual ICollection<AplikantObrazovanje> AplikantObrazovanje { get; set; }
    }
}
