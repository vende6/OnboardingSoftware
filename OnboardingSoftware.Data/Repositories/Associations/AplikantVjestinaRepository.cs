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
    public class AplikantVjestinaRepository : Repository<AplikantVjestina>, IAplikantVjestinaRepository
    {
        public AplikantVjestinaRepository(OnboardingSoftwareDbContext context)
          : base(context)
        { }

        private OnboardingSoftwareDbContext OnboardingSoftwareDbContext
        {
            get { return Context as OnboardingSoftwareDbContext; }
        }

        public async Task<IEnumerable<AplikantVjestina>> GetApplicantSkillsAsync(int aplikantId)
        {
            return await OnboardingSoftwareDbContext.AplikantVjestina
              .Include(a => a.Vjestina)
              .Where(a => a.AplikantID == aplikantId)
              .ToListAsync();
        }
    }
}
