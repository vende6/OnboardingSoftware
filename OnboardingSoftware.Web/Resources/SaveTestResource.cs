using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnboardingSoftware.Web.Resources
{
    public class SaveTestResource
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
        public string Tip { get; set; }
        public string Trajanje { get; set; }
        public DateTime Pocetak { get; set; }
        public DateTime Kraj { get; set; }
        public string BrojPitanja { get; set; }
        public string OsvojeniProcenat { get; set; }
    }
}
