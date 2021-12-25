using OnboardingSoftware.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingSoftware.Core.Services
{
    public interface IInteresService
    {
        Task<IEnumerable<Interes>> GetInterestsAsync();
        Task<Interes> CreateInteres(Interes newVjestina);
    }
}
