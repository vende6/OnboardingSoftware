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
        
        public async Task<IEnumerable<Aplikant>> GetAllWithMusicsAsync()
        {
            return await OnboardingSoftwareDbContext.Aplikanti
                .Include(a => a.Vjestine)
                .ToListAsync();
        }

        Task<IEnumerable<Aplikant>> IAplikantRepository.GetAllWithMusicsAsync()
        {
            throw new NotImplementedException();
        }

        Task<Aplikant> IAplikantRepository.GetWithMusicsByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        private OnboardingSoftwareDbContext OnboardingSoftwareDbContext
        {
            get { return Context as OnboardingSoftwareDbContext; }
        }
    }
}
