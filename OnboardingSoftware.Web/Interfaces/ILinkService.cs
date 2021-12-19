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
        Task<IEnumerable<OdgovorViewModel>> GetAnswers(string userId);
        Task<LinkViewModel> GetLinkById(int id);
        Task<bool> CreateJob(PosaoViewModel link);
        Task<bool> CreateTest(TestViewModel link);
        Task<bool> CreateQuestion(PitanjeViewModel link);
        Task<bool> CreateAnswer(OdgovorViewModel link);
        //Task<LinkResource> CheckLinkForOccurance(string name);
    }
}
