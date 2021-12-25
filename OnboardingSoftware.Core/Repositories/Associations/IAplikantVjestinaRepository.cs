using OnboardingSoftware.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingSoftware.Core.Repositories.Associations
{
    public interface IAplikantVjestinaRepository : IRepository<AplikantVjestina>
    {
        Task<IEnumerable<AplikantVjestina>> GetAplikantSkillsAsync(int aplikantId);
    }
}
