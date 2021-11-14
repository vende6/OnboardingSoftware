using OnboardingSoftware.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingSoftware.Core.Services
{
    public interface IVjestinaService
    {
        Task<IEnumerable<Vjestina>> GetAllWithAplikant();
        Task<Vjestina> GetVjestinaById(int id);
        Task<IEnumerable<Vjestina>> GetVjestineByAplikantId(int aplikantId);
        Task<Vjestina> CreateMusic(Vjestina newVjestina);
        Task UpdateMusic(Vjestina vjestinaToBeUpdated, Vjestina vjestina);
        Task DeleteMusic(Vjestina vjestina);
    }
}
