using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnboardingSoftware.Web.Models;
using OnboardingSoftware.Web.Resources;

namespace OnboardingSoftware.Web.Interfaces
{
    public interface ILinkService
    {
         Task<IEnumerable<AplikantViewModel>> GetLinks(string userId);
        Task<IEnumerable<PosaoViewModel>> GetJobs(string userId);
        Task<IEnumerable<TestViewModel>> GetTests(string userId);
        Task<IEnumerable<PitanjeViewModel>> GetQuestions(string userId);
        Task<LinkViewModel> GetLinkById(int id);
         Task<bool> CreateLink(LinkResource link);
         Task<LinkResource> CheckLinkForOccurance(string name);
    }
}
