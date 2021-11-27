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
    public class VjestinaRepository : Repository<Vjestina>, IVjestinaRepository
    {
        public VjestinaRepository(OnboardingSoftwareDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Vjestina>> GetAllWithAplikantiAsync()
        {
            return await OnboardingSoftwareDbContext.Vjestine
                .Include(m => m.AplikantVjestina)
                .ToListAsync();
        }

        public async Task<Vjestina> GetWithAplikantiByIdAsync(int id)
        {
            return await OnboardingSoftwareDbContext.Vjestine
                .Include(m => m.AplikantVjestina)
                .SingleOrDefaultAsync(m => m.ID == id);
        }


        private OnboardingSoftwareDbContext OnboardingSoftwareDbContext
        {
            get { return Context as OnboardingSoftwareDbContext; }
        }
    }
}
