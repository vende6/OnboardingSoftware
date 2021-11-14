using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingSoftware.Core.Models
{
    public class Test
    {
        public Test()
        {
            this.Aplikanti = new HashSet<Aplikant>();
        }

        public int ID { get; set; }
        public string Naziv { get; set; }
        public string Tip { get; set; }
        public string Trajanje { get; set; }
        public DateTime Pocetak { get; set; }
        public DateTime Kraj { get; set; }
        public string BrojPitanja { get; set; }
        public string OsvojeniProcenat { get; set; }
        public virtual ICollection<Aplikant> Aplikanti { get; set; }

    }
}
