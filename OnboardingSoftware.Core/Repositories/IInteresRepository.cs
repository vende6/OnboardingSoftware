using OnboardingSoftware.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingSoftware.Core.Repositories
{
    public interface IInteresRepository : IRepository<Interes>
    {
        Task<IEnumerable<Interes>> GetInterestsAsync();
    }
}
