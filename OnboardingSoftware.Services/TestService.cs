using OnboardingSoftware.Core;
using OnboardingSoftware.Core.Models;
using OnboardingSoftware.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingSoftware.Services
{
    public class TestService : ITestService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TestService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateTest(Test newTest)
        {
            await _unitOfWork.Testovi.AddAsync(newTest);
            await _unitOfWork.CommitAsync();
            return true;
        }

        public async Task<Test> GetTestById(int testId)
        {
            return await _unitOfWork.Testovi.GetTestByIdAsync(testId);
        }

        public async Task<IEnumerable<Test>> GetTestovi()
        {
            return await _unitOfWork.Testovi.GetTestsAsync();
        }

    }
}
