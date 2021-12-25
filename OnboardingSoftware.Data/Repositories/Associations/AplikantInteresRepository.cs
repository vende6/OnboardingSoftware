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

        public Task<IEnumerable<AplikantInteres>> GetAplikantInterestsAsync(int aplikantId)
        {
            throw new NotImplementedException();
        }
    }
}
