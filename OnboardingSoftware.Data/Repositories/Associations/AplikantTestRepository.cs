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
    public class AplikantTestRepository : Repository<AplikantTest>, IAplikantTestRepository
    {
        public AplikantTestRepository(OnboardingSoftwareDbContext context)
          : base(context)
        { }

        public async Task<IEnumerable<AplikantTest>> GetApplicantsTestAsync(int testId)
        {
            return await OnboardingSoftwareDbContext.AplikantTest
             .Include(a => a.Aplikant)
             .Where(a => a.TestID == testId)
             .ToListAsync();
        }

        private OnboardingSoftwareDbContext OnboardingSoftwareDbContext
        {
            get { return Context as OnboardingSoftwareDbContext; }
        }
    }
}
