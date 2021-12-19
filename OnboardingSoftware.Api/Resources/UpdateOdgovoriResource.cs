using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace OnboardingSoftware.Api.Resources
{
    public class UpdateOdgovoriResource
    {
        public IEnumerable<OdgovorResource> Odgovori { get; set; }
    }
}
