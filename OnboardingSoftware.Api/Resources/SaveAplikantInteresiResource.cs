using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnboardingSoftware.Api.Resources
{
    public class SaveAplikantInteresiResource
    {
        public string Email { get; set; }
        [JsonIgnore]
        public int AplikantID { get; set; }
        public IEnumerable<SaveInteresResource> Interesi { get; set; }

    }
}
