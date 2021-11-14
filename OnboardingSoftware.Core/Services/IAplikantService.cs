using OnboardingSoftware.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingSoftware.Core.Services
{
    public interface IAplikantService
    {
        Task<IEnumerable<Aplikant>> GetAllArtists();
        Task<Aplikant> GetArtistById(int id);
        Task<Aplikant> CreateArtist(Aplikant newArtist);
        Task UpdateArtist(Aplikant artistToBeUpdated, Aplikant artist);
        Task DeleteArtist(Aplikant artist);
    }
}
