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

        private OnboardingSoftwareDbContext OnboardingSoftwareDbContext
        {
            get { return Context as OnboardingSoftwareDbContext; }
        }
    }
}
