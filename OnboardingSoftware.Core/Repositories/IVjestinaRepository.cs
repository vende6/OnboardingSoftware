using OnboardingSoftware.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingSoftware.Core.Repositories
{
    public interface IVjestinaRepository : IRepository<Vjestina>
    {
        Task<IEnumerable<Vjestina>> GetAllWithArtistAsync();
        Task<Vjestina> GetWithArtistByIdAsync(int id);
        Task<IEnumerable<Vjestina>> GetAllWithArtistByArtistIdAsync(int artistId);
    }
}
