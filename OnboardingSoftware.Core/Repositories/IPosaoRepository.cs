using OnboardingSoftware.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingSoftware.Core.Repositories
{
    public interface IPosaoRepository : IRepository<Posao>
    {
        Task<IEnumerable<Posao>> GetAllWithLokacijaAsync();
        Task<Posao> GetWithVjestineByIdAsync(int id);
    }
}
