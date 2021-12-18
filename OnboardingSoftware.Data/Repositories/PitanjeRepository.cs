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
    public class PitanjeRepository : Repository<Pitanje>, IPitanjeRepository
    {
        public PitanjeRepository(OnboardingSoftwareDbContext context)
          : base(context)
        { }

        private OnboardingSoftwareDbContext OnboardingSoftwareDbContext
        {
            get { return Context as OnboardingSoftwareDbContext; }
        }

        public async Task<IEnumerable<Pitanje>> GetQuestionsAsync()
        {
            return await OnboardingSoftwareDbContext.Pitanja
                .Include(x=>x.Test)
                .ToListAsync();
        }

        public async Task<IEnumerable<Pitanje>> GetPitanjaByTestIdAsync(int testId)
        {
             return await OnboardingSoftwareDbContext.Pitanja
                .Include(x=>x.Test)
                .Where(x=>x.Test.ID == testId)
                .ToListAsync();
        }
    }
}
