using Newtonsoft.Json;
using OnboardingSoftware.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnboardingSoftware.Api.Resources
{
    public class PitanjeResource
    {
        public int ID { get; set; }
        public string Tekst { get; set; }
        public string Tip { get; set; }
        public string RedniBroj { get; set; }
        public string Test { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<OdgovorResource> Odgovori { get; set; }
    }
}
