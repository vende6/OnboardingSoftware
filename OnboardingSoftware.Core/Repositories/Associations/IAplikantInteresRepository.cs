using OnboardingSoftware.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingSoftware.Core.Repositories.Associations
{
    public interface IAplikantInteresRepository : IRepository<AplikantInteres>
    {
        Task<IEnumerable<AplikantInteres>> GetApplicantInterestsAsync(int aplikantId);
    }
}
