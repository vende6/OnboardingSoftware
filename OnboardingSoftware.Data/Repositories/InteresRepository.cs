using Microsoft.EntityFrameworkCore;
using OnboardingSoftware.Core.Models;
using OnboardingSoftware.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingSoftware.Data.Repositories
{
    public class InteresRepository : Repository<Interes>, IInteresRepository
    {
        public InteresRepository(OnboardingSoftwareDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Interes>> GetInterestsAsync()
        {
            return await OnboardingSoftwareDbContext.Interesi.ToListAsync();
        }

        private OnboardingSoftwareDbContext OnboardingSoftwareDbContext
        {
            get { return Context as OnboardingSoftwareDbContext; }
        }
    }
}