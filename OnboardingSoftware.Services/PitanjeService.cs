using OnboardingSoftware.Core;
using OnboardingSoftware.Core.Models;
using OnboardingSoftware.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingSoftware.Services
{
    public class PitanjeService : IPitanjeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PitanjeService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<bool> CreatePitanje(Pitanje newPitanje)
        {
            await _unitOfWork.Pitanja.AddAsync(newPitanje);
            await _unitOfWork.CommitAsync();
            return true;
        }

        public async Task<IEnumerable<Pitanje>> GetPitanja()
        {
            return await _unitOfWork.Pitanja.GetQuestionsAsync();
        }
    }
}
