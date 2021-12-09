using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnboardingSoftware.Web.Models.Auth;

namespace OnboardingSoftware.Web.Interfaces
{
    public interface IAuthService
    {
        Task<bool> Login(LoginViewModel model);
        Task<bool> Register(RegisterViewModel model);
    }
}
