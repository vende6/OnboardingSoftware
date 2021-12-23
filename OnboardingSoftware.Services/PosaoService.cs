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
    public class PosaoService : IPosaoService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PosaoService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Posao> CreatePosao(Posao newPosao)
        {
            await _unitOfWork.Poslovi.AddAsync(newPosao);
            await _unitOfWork.CommitAsync();
            return newPosao;
        }

        public async Task<IEnumerable<Posao>> GetAllWithLokacija()
        {
            return await _unitOfWork.Poslovi
                .GetAllWithLokacijaAsync();
        }

        public async Task<Posao> GetPosaoById(int posaoId)
        {
            return await _unitOfWork.Poslovi.GetPosaoByIdAsync(posaoId);
        }

    }
}
