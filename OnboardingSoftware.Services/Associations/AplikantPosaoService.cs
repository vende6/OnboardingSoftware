using OnboardingSoftware.Core;
using OnboardingSoftware.Core.Models;
using OnboardingSoftware.Core.Services.Associations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingSoftware.Services
{
    public class AplikantPosaoService : IAplikantPosaoService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AplikantPosaoService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<AplikantPosao> CreateAplikantPosao(AplikantPosao newaplikantPosao)
        {
            await _unitOfWork.AplikantPosao.AddAsync(newaplikantPosao);
            await _unitOfWork.CommitAsync();
            return newaplikantPosao;
        }
    }
}
