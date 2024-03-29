﻿using OnboardingSoftware.Core;
using OnboardingSoftware.Core.Models;
using OnboardingSoftware.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingSoftware.Services
{
    public class VjestinaService : IVjestinaService
    {
        private readonly IUnitOfWork _unitOfWork;
        public VjestinaService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateVjestina(Vjestina newVjestina)
        {
            await _unitOfWork.Vjestine.AddAsync(newVjestina);
            await _unitOfWork.CommitAsync();
            return true;
        }

        public async Task<IEnumerable<Vjestina>> GetSkillsAsync()
        {
            return await _unitOfWork.Vjestine.GetSkillsAsync();
        }
    }
}
