using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OnboardingSoftware.Core.Models
{
    public class Vjestina
    {
        public Vjestina()
        {
            this.AplikantVjestina = new HashSet<AplikantVjestina>();
        }
        public int ID { get; set; }
        public string Naziv { get; set; }

        [JsonIgnore]
        public virtual ICollection<AplikantVjestina> AplikantVjestina { get; set; }
    }
}
