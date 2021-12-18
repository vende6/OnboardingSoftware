using Microsoft.EntityFrameworkCore;
using OnboardingSoftware.Core.Models;
using OnboardingSoftware.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingSoftware.Data.Repositories
{
    public class OdgovorRepository : Repository<Odgovor>, IOdgovorRepository
    {
        public OdgovorRepository(OnboardingSoftwareDbContext context)
        : base(context)
        { }

        private OnboardingSoftwareDbContext OnboardingSoftwareDbContext
        {
            get { return Context as OnboardingSoftwareDbContext; }
        }

        public async Task<IEnumerable<Odgovor>> GetOdgovoriByPitanjeIdAsync(int pitanjeId)
        {
            return await OnboardingSoftwareDbContext.Odgovori
              .Include(x => x.Pitanje)
              .Where(x => x.Pitanje.ID == pitanjeId)
              .ToListAsync();
        }
    }
}