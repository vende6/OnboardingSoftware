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
    public class AplikantService : IAplikantService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AplikantService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Aplikant> CreateAplikant(Aplikant newAplikant)
        {
            await _unitOfWork.Aplikanti.AddAsync(newAplikant);
            await _unitOfWork.CommitAsync();
            return newAplikant;
        }

        public async Task DeleteAplikant(Aplikant aplikant)
        {
            _unitOfWork.Aplikanti.Remove(aplikant);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Aplikant>> GetAllWithVjestine()
        {
            return await _unitOfWork.Aplikanti
                .GetAllWithVjestineAsync();
        }

        public async Task<Aplikant> GetAplikantById(int id)
        {
            return await _unitOfWork.Aplikanti
                .GetWithVjestineByIdAsync(id);
        }

        public async Task UpdateAplikant(Aplikant aplikantToBeUpdated, Aplikant aplikant)
        {
            aplikantToBeUpdated.Ime = aplikant.Ime;
            aplikantToBeUpdated.Prezime = aplikant.Prezime;

            await _unitOfWork.CommitAsync();
        }
    }
}
