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

        public async Task<bool> CreateAplikantInteresi(IEnumerable<AplikantInteres> newaplikantInteresi)
        {
            var aplikantId = newaplikantInteresi.FirstOrDefault().AplikantID;

            var interests = await _unitOfWork.AplikantInteres.GetApplicantInterestsAsync(aplikantId);

            _unitOfWork.AplikantInteres.RemoveRange(interests);

            await _unitOfWork.AplikantInteres.AddRangeAsync(newaplikantInteresi);
            await _unitOfWork.CommitAsync();
            return true;
        }

    }
}
