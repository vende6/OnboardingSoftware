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

        private OnboardingSoftwareDbContext OnboardingSoftwareDbContext
        {
            get { return Context as OnboardingSoftwareDbContext; }
        }

        public Task<IEnumerable<Interes>> GetInterestsAsync()
        {
            throw new NotImplementedException();
        }
    }
}