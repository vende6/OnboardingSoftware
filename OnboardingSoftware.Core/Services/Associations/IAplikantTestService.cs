using OnboardingSoftware.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingSoftware.Core.Services.Associations
{
    public interface IAplikantPosaoService
    {
        Task<IEnumerable<AplikantPosao>> GetApplicantsPosao(int posaoId);
        Task<AplikantPosao> CreateAplikantPosao(AplikantPosao newaplikantPosao);
    }
}
