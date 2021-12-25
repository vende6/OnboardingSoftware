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
    public class AplikantPosaoRepository : Repository<AplikantPosao>, IAplikantPosaoRepository
    {
        public AplikantPosaoRepository(OnboardingSoftwareDbContext context)
          : base(context)
        { }

        public async Task<IEnumerable<AplikantPosao>> GetApplicantsJobAsync(int posaoId)
        {
            return await OnboardingSoftwareDbContext.AplikantPosao
              .Include(a => a.Aplikant)
              .Where(a => a.PosaoID == posaoId)
              .ToListAsync();
        }

        private OnboardingSoftwareDbContext OnboardingSoftwareDbContext
        {
            get { return Context as OnboardingSoftwareDbContext; }
        }
    }
}
