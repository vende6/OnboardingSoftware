using OnboardingSoftware.Core;
using OnboardingSoftware.Core.Models;
using OnboardingSoftware.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingSoftware.Services
{
    public class OdgovorService : IOdgovorService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OdgovorService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateOdgovor(Odgovor newOdgovor)
        {
            await _unitOfWork.Odgovori.AddAsync(newOdgovor);
            await _unitOfWork.CommitAsync();
            return true;
        }

        public async Task<IEnumerable<Odgovor>> GetOdgovori()
        {
            return await _unitOfWork.Odgovori.GetOdgovoriAsync();
        }

        public async Task<IEnumerable<Odgovor>> GetOdgovoriByPitanjeId(int pitanjeId)
        {
            return await _unitOfWork.Odgovori.GetOdgovoriByPitanjeIdAsync(pitanjeId);
        }

        public async Task<bool> UpdateOdgovori(IEnumerable<Odgovor> odgovori)
        {
            _unitOfWork.Odgovori.UpdateRange(odgovori);
            await _unitOfWork.CommitAsync();
            return true;
        }
    }
}
