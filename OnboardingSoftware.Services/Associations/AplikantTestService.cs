using OnboardingSoftware.Core;
using OnboardingSoftware.Core.Models;
using OnboardingSoftware.Core.Services.Associations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingSoftware.Services
{
    public class AplikantTestService : IAplikantTestService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AplikantTestService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<AplikantTest> CreateAplikantTest(AplikantTest newaplikantTest)
        {
            await _unitOfWork.AplikantTest.AddAsync(newaplikantTest);
            await _unitOfWork.CommitAsync();
            return newaplikantTest;
        }
    }
}
