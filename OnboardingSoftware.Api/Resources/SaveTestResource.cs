using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnboardingSoftware.Api.Resources
{
    public class SaveTestResource
    {
        public string Naziv { get; set; }
        public string Tip { get; set; }
        public string Trajanje { get; set; }
        public string BrojPitanja { get; set; }
    }
}
