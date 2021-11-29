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
        Task<IEnumerable<Aplikant>> GetAllWithVjestine();
        Task<Aplikant> GetAplikantById(int id);
        Task<Aplikant> CreateAplikant(Aplikant newArtist);
        Task UpdateAplikant(Aplikant artistToBeUpdated, Aplikant artist);
        Task DeleteAplikant(Aplikant artist);
    }
}
