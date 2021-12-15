using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSoftware.Core.Models.Auth
{
    using System;
    using Microsoft.AspNetCore.Identity;

    namespace MyMusic.Core.Models.Auth
    {
        public class Role : IdentityRole<Guid>
        { }
    }
}
