using OnboardingSoftware.Core;
using OnboardingSoftware.Core.Models;
using OnboardingSoftware.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingSoftware.Services
{
    public class InteresService : IInteresService
    {
        private readonly IUnitOfWork _unitOfWork;
        public InteresService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateInteres(Interes newInteres)
        {
            await _unitOfWork.Interesi.AddAsync(newInteres);
            await _unitOfWork.CommitAsync();
            return true;
        }

        public async Task<IEnumerable<Interes>> GetInterests()
        {
            return await _unitOfWork.Interesi.GetInterestsAsync();
        }
    }
}
