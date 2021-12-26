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
    public class AplikantRepository : Repository<Aplikant>, IAplikantRepository
    {
          public AplikantRepository(OnboardingSoftwareDbContext context) 
            : base(context)
        { }
        
        

        public async Task<IEnumerable<Aplikant>> GetAllAsync()
        {
            return await OnboardingSoftwareDbContext.Aplikanti
                .ToListAsync();
        }

        public async Task<Aplikant> GetByEmailAsync(string email)
        {
            return await OnboardingSoftwareDbContext.Aplikanti
                .Where(a => a.Email == email)
                .FirstOrDefaultAsync();
        }


        public async Task<Aplikant> GetWithVjestineByIdAsync(int id)
        {
            return await OnboardingSoftwareDbContext.Aplikanti
                .Include(a => a.AplikantVjestina)
                .Where(a => a.ID == id)
                .FirstOrDefaultAsync();
        }

        private OnboardingSoftwareDbContext OnboardingSoftwareDbContext
        {
            get { return Context as OnboardingSoftwareDbContext; }
        }
    }
}
