using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnboardingSoftware.Api.Resources
{
    public class UpdateAplikantResource
    {
        public string BrojTelefona { get; set; }
        public string MjestoRodjenja { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string Adresa { get; set; }
        public string Bio { get; set; }
        public string StatusZaposlenja { get; set; }
        public string Industrija { get; set; }
    }
}
