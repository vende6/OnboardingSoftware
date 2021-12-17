using OnboardingSoftware.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingSoftware.Core.Services
{
    public interface IPitanjeService
    {
        Task<IEnumerable<Pitanje>> GetPitanja();
        Task<IEnumerable<Pitanje>> GetPitanjaByTestId(int testId);
        Task<bool> CreatePitanje(Pitanje pitanje);
    }
}
