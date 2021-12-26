using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnboardingSoftware.Api.Resources
{
    public class AplikantVjestineResource
    {
        public IEnumerable<VjestinaResource> Vjestine { get; set; }
    }
}
