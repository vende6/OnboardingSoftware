using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingSoftware.Core.Models
{
    public class AplikantPosao
    {
        public int AplikantID { get; set; }
        public virtual Aplikant Aplikant { get; set; }
        public int PosaoID { get; set; }
        public virtual Posao Posao { get; set; }
        public string PopratnoPismo { get; set; }
    }
}
