using OnboardingSoftware.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingSoftware.Core.Services
{
    public interface IVjestinaService
    {
        Task<IEnumerable<Vjestina>> GetAllWithArtist();
        Task<Vjestina> GetMusicById(int id);
        Task<IEnumerable<Vjestina>> GetMusicsByArtistId(int artistId);
        Task<Vjestina> CreateMusic(Vjestina newMusic);
        Task UpdateMusic(Vjestina musicToBeUpdated, Vjestina music);
        Task DeleteMusic(Vjestina music);
    }
}
