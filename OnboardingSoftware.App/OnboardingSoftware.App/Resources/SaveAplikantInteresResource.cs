using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSoftware.App.Resources
{
    public class SaveAplikantInteresResource
    {
        public string Email { get; set; }
        [JsonIgnore]
        public int AplikantID { get; set; }
        public int InteresID { get; set; }
    }
}
