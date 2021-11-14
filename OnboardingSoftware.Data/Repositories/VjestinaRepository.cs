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

        public async Task<IEnumerable<Vjestina>> GetAllWithArtistAsync()
        {
            return await OnboardingSoftwareDbContext.Vjestine
                .Include(m => m.Aplikanti)
                .ToListAsync();
        }

        public async Task<Vjestina> GetWithArtistByIdAsync(int id)
        {
            return await OnboardingSoftwareDbContext.Vjestine
                .Include(m => m.Aplikanti)
                .SingleOrDefaultAsync(m => m.ID == id); ;
        }

        public async Task<IEnumerable<Vjestina>> GetAllWithArtistByArtistIdAsync(int vjestinaId)
        {
            return await OnboardingSoftwareDbContext.Vjestine
                .Include(m => m.Aplikanti)
                .Where(m => m.ID == vjestinaId)
                .ToListAsync();
        }

        Task<Vjestina> IVjestinaRepository.GetWithArtistByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Vjestina>> IVjestinaRepository.GetAllWithArtistByArtistIdAsync(int vjestinaId)
        {
            throw new NotImplementedException();
        }

        private OnboardingSoftwareDbContext OnboardingSoftwareDbContext
        {
            get { return Context as OnboardingSoftwareDbContext; }
        }
    }
}
