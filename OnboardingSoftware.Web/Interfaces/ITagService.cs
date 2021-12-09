using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnboardingSoftware.Web.Models;
using OnboardingSoftware.Web.Resources;

namespace OnboardingSoftware.Web.Interfaces
{
    public interface ITagService
    {
        Task<IEnumerable<TagResource>> GetTags();
        Task<TagViewModel> GetTagById(int id);
        Task<TagResource> CreateTag(TagResource tag);
        Task<IEnumerable<TagResource>> GetTagsByLinkId(int linkId);
        Task<TagResource> CheckTagForOccuranceAsync(string url, string tagname);
        Task<List<Tuple<int, string, int>>> GetTagsByOccurancesAndLinkIdAsync(int linkId);
    }
}
