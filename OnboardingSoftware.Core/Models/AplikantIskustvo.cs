using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingSoftware.Core.Models
{
    public class AplikantIskustvo
    {
        public int AplikantID { get; set; }
        public virtual Aplikant Aplikant { get; set; }
        public int IskustvoID { get; set; }
        public virtual Iskustvo Iskustvo { get; set; }
    }
}
