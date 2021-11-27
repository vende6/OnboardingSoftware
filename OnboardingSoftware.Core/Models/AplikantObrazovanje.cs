using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingSoftware.Core.Models
{
    public class AplikantObrazovanje
    {
        public int AplikantID { get; set; }
        public virtual Aplikant Aplikant { get; set; }
        public int ObrazovanjeID { get; set; }
        public virtual Obrazovanje Obrazovanje { get; set; }
    }
}
