using Microsoft.EntityFrameworkCore;
using OnboardingSoftware.Core.Models;
using OnboardingSoftware.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingSoftware.Data.Repositories
{
    public class TestRepository : Repository<Test>, ITestRepository
    {
        public TestRepository(OnboardingSoftwareDbContext context)
          : base(context)
        { }

        private OnboardingSoftwareDbContext OnboardingSoftwareDbContext
        {
            get { return Context as OnboardingSoftwareDbContext; }
        }

        public async Task<IEnumerable<Test>> GetTestsAsync()
        {
         
                return await OnboardingSoftwareDbContext.Testovi
                   .ToListAsync();
           
        }
    }
}
