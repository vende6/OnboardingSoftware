using Microsoft.EntityFrameworkCore;
using OnboardingSoftware.Core.Models;
using OnboardingSoftware.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingSoftware.Data.Repositories
{
    public class PosaoRepository : Repository<Posao>, IPosaoRepository
    {
        public PosaoRepository(OnboardingSoftwareDbContext context)
          : base(context)
        { }


        public async Task<IEnumerable<Posao>> GetAllWithLokacijaAsync()
        {
            return await OnboardingSoftwareDbContext.Poslovi
               .Include(a => a.Lokacija)
               .ToListAsync();
        }

        Task<Posao> IPosaoRepository.GetWithVjestineByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        private OnboardingSoftwareDbContext OnboardingSoftwareDbContext
        {
            get { return Context as OnboardingSoftwareDbContext; }
        }
    }
}
