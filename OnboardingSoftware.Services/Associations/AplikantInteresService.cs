using OnboardingSoftware.Core;
using OnboardingSoftware.Core.Models;
using OnboardingSoftware.Core.Services.Associations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingSoftware.Services.Associations
{
    public class AplikantInteresService : IAplikantInteresService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AplikantInteresService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<AplikantInteres>> GetApplicantsInterests()
        {
            return await _unitOfWork.AplikantInteres.GetApplicantsInterestsAsync();
        }

        public async Task<IEnumerable<AplikantInteres>> GetApplicantInterests(int aplikantId)
        {
            return await _unitOfWork.AplikantInteres.GetApplicantInterestsAsync(aplikantId);
        }

        public async Task<AplikantInteres> CreateAplikantInteres(AplikantInteres newaplikantInteres)
        {
            await _unitOfWork.AplikantInteres.AddAsync(newaplikantInteres);
            await _unitOfWork.CommitAsync();
            return newaplikantInteres;
        }

    }
}
