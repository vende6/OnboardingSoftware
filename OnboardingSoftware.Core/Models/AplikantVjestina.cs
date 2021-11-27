using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingSoftware.Core.Models
{
    public class AplikantVjestina
    {
        public int AplikantID { get; set; }
        public virtual Aplikant Aplikant { get; set; }
        public int VjestinaID { get; set; }
        public virtual Vjestina Vjestina { get; set; }
    }
}
