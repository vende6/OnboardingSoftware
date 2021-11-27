using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingSoftware.Core.Models
{
    public class AplikantInteres
    {
        public int AplikantID { get; set; }
        public virtual Aplikant Aplikant { get; set; }
        public int InteresID { get; set; }
        public virtual Interes Interes { get; set; }
    }
}
