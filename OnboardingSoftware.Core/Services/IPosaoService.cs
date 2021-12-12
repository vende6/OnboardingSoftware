using OnboardingSoftware.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingSoftware.Core.Services
{
    public interface IPosaoService
    {
        Task<IEnumerable<Posao>> GetAllWithLokacija();
        Task<Posao> CreatePosao(Posao newPosao);
    }
}
