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

        public async Task<IEnumerable<Aplikant>> GetAll()
        {
            return await _unitOfWork.Aplikanti
                .GetAllAsync();
        }

        public async Task<Aplikant> GetAplikantByEmail(string email)
        {
            return await _unitOfWork.Aplikanti
                .GetByEmailAsync(email);
        }

        public async Task<Aplikant> GetAplikantById(int id)
        {
            return await _unitOfWork.Aplikanti
                .GetWithVjestineByIdAsync(id);
        }

        public async Task UpdateAplikant(Aplikant aplikantToBeUpdated, Aplikant aplikant)
        {
            aplikantToBeUpdated.BrojTelefona = aplikant.BrojTelefona;
            aplikantToBeUpdated.Adresa = aplikant.Adresa;
            aplikantToBeUpdated.DatumRodjenja = aplikant.DatumRodjenja;
            aplikantToBeUpdated.MjestoRodjenja = aplikant.MjestoRodjenja;
            aplikantToBeUpdated.StatusZaposlenja = aplikant.StatusZaposlenja;
            aplikantToBeUpdated.TrenutnaPozicija = aplikant.TrenutnaPozicija;
            aplikantToBeUpdated.Industrija = aplikant.Industrija;
            aplikantToBeUpdated.Bio = aplikant.Bio;

            _unitOfWork.Aplikanti.Update(aplikantToBeUpdated);
            await _unitOfWork.CommitAsync();
        }
    }
}
