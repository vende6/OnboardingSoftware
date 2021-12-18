using OnboardingSoftware.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingSoftware.Core.Repositories
{
    public interface IOdgovorRepository : IRepository<Odgovor>
    {
        Task<IEnumerable<Odgovor>> GetOdgovoriByPitanjeIdAsync(int pitanjeId);
    }
}
