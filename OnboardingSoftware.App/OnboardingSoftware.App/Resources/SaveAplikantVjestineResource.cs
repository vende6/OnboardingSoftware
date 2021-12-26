using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSoftware.App.Resources
{
    public class SaveAplikantVjestineResource
    {
        public string Email { get; set; }
        [JsonIgnore]
        public int AplikantID { get; set; }
        public List<SaveVjestinaResource> Vjestine { get; set; }
    }
}
