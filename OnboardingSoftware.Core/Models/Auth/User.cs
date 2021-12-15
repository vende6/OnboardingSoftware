using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSoftware.Core.Models.Auth
{
    using System;
    using Microsoft.AspNetCore.Identity;

    namespace MyMusic.Core.Models.Auth
    {
        public class User : IdentityUser<Guid>
        {
            public string FirstName { get; set; }

            public string LastName { get; set; }
        }
    }
}
