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
        Task<IEnumerable<Aplikant>> GetAll();
        Task<Aplikant> GetAplikantById(int id);
        Task<Aplikant> GetAplikantByEmail(string email);
        Task<Aplikant> CreateAplikant(Aplikant newArtist);
        Task UpdateAplikant(Aplikant aplikantToBeUpdated, Aplikant aplikant);
        Task DeleteAplikant(Aplikant artist);
    }
}
