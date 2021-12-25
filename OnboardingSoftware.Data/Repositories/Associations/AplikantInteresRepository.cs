using Microsoft.EntityFrameworkCore;
using OnboardingSoftware.Core.Models;
using OnboardingSoftware.Core.Repositories.Associations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingSoftware.Data.Repositories.Associations
{
    public class AplikantInteresRepository : Repository<AplikantInteres>, IAplikantInteresRepository
    {
        public AplikantInteresRepository(OnboardingSoftwareDbContext context)
          : base(context)
        { }

        private OnboardingSoftwareDbContext OnboardingSoftwareDbContext
        {
            get { return Context as OnboardingSoftwareDbContext; }
        }

        public async Task<IEnumerable<AplikantInteres>> GetApplicantsInterestsAsync()
        {
            return await OnboardingSoftwareDbContext.AplikantInteres
            .Include(a => a.Interes)
            .ToListAsync();
        }

        public async Task<IEnumerable<AplikantInteres>> GetApplicantInterestsAsync(int aplikantId)
        {
            return await OnboardingSoftwareDbContext.AplikantInteres
              .Include(a => a.Interes)
              .Where(a => a.AplikantID == aplikantId)
              .ToListAsync();
        }

    }
}
