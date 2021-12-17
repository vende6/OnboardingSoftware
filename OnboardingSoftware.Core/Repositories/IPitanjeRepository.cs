using OnboardingSoftware.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingSoftware.Core.Repositories
{
    public interface IPitanjeRepository : IRepository<Pitanje>
    {
        Task<IEnumerable<Pitanje>> GetQuestionsAsync();
        Task<IEnumerable<Pitanje>> GetPitanjaByTestIdAsync(int testId);
    }
}
