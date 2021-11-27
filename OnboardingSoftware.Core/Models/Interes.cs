using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingSoftware.Core.Models
{
    public class Interes
    {
        public Interes()
        {
            this.AplikantInteres = new HashSet<AplikantInteres>();
        }
        public int ID { get; set; }
        public string Naziv { get; set; }

        //public virtual ICollection<Aplikant> Aplikanti { get; set; }
        public virtual ICollection<AplikantInteres> AplikantInteres { get; set; }

    }
}
