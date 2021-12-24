using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnboardingSoftware.Api.Resources
{
    public class SaveAplikantTestResource
    {
        public string Email { get; set; }
        public int TestID { get; set; }
        [JsonIgnore]
        public int AplikantID { get; set; }
    }
}
