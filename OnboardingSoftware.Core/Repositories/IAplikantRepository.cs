using OnboardingSoftware.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingSoftware.Core.Repositories
{
    public interface IAplikantRepository : IRepository<Aplikant>
    {
        Task<IEnumerable<Aplikant>> GetAllWithVjestineAsync();
        Task<Aplikant> GetByEmailAsync(string email);
        Task<Aplikant> GetWithVjestineByIdAsync(int id);
    }
}
