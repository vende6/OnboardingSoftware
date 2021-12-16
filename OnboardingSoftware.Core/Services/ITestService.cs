using OnboardingSoftware.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingSoftware.Core.Services
{
    public interface ITestService
    {
        Task<IEnumerable<Test>> GetTestovi();
        Task<Test> GetTestById(int testId);
        Task<bool> CreateTest(Test test);
    }
}
