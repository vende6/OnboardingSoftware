using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingSoftware.Core.Models
{
    public class AplikantTest
    {
        public int AplikantID { get; set; }
        public virtual Aplikant Aplikant { get; set; }
        public int TestID { get; set; }
        public virtual Test Test { get; set; }
    }
}
