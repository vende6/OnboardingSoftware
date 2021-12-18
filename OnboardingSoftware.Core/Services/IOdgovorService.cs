using OnboardingSoftware.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingSoftware.Core.Services
{
    public interface IOdgovorService
    {
        Task<IEnumerable<Odgovor>> GetOdgovoriByPitanjeId(int pitanjeId);
    }
}
