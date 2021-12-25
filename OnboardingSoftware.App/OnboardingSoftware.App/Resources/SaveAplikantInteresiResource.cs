using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSoftware.App.Resources
{
    public class SaveAplikantInteresiResource
    {
        public string Email { get; set; }
        [JsonIgnore]
        public int AplikantID { get; set; }
        public List<SaveInteresResource> Interesi { get; set; }

    }
}
