using OnboardingSoftware.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingSoftware.Core.Repositories
{
    public interface ITestRepository : IRepository<Test>
    {
        Task<IEnumerable<Test>> GetTestsAsync();
        Task<Test> GetTestByIdAsync(int testId);
    }
}
