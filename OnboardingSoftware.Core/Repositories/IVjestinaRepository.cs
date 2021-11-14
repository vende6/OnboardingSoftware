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
        Task<IEnumerable<Vjestina>> GetAllWithAplikantiAsync();
        Task<Vjestina> GetWithAplikantiByIdAsync(int id);
    }
}
