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
    public class AplikantVjestinaService : IAplikantVjestinaService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AplikantVjestinaService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<AplikantVjestina>> GetApplicantSkills(int aplikantId)
        {
            return await _unitOfWork.AplikantVjestina.GetApplicantSkillsAsync(aplikantId);
        }

        public async Task<AplikantVjestina> CreateAplikantVjestina(AplikantVjestina newaplikantVjestina)
        {
            await _unitOfWork.AplikantVjestina.AddAsync(newaplikantVjestina);
            await _unitOfWork.CommitAsync();
            return newaplikantVjestina;
        }
    }
}
