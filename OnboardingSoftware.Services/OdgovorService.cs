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

        public async Task<IEnumerable<Odgovor>> GetOdgovoriByPitanjeId(int pitanjeId)
        {
            return await _unitOfWork.Odgovori.GetOdgovoriByPitanjeIdAsync(pitanjeId);
        }
    }
}
