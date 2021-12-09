using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using OnboardingSoftware.Web.Interfaces;
using OnboardingSoftware.Web.Models;
using OnboardingSoftware.Web.Resources;
using static OnboardingSoftware.Web.Settings;

namespace OnboardingSoftware.Web.Services
{
    public class TagService : ITagService
    {
        public HttpClient _httpClient { get; set; }
        private string tagsUrl;
        public TagService(IHttpClientFactory httpClientFactory, ApiEndpoint apiEndpoint)
        {
            _httpClient = httpClientFactory.CreateClient();
             tagsUrl = apiEndpoint.TagsEndpointUrl;
            _httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue(JwtBearerDefaults.AuthenticationScheme, jwtToken);
        }
        public async Task<IEnumerable<TagResource>> GetTags()
        {
            try
            {
                List<TagResource> tags = new List<TagResource>();
                var response = await _httpClient.GetAsync(tagsUrl);
                string apiResponse = await response.Content.ReadAsStringAsync();
                tags = JsonConvert.DeserializeObject<List<TagResource>>(apiResponse);

                return tags;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        public async Task<IEnumerable<TagResource>> GetTagsByLinkId(int linkId) 
        {
            try
            {
                List<TagResource> tags = new List<TagResource>();
                var response = await _httpClient.GetAsync(tagsUrl+ "/bylinkid/" + linkId);
                string apiResponse = await response.Content.ReadAsStringAsync();
                tags = JsonConvert.DeserializeObject<List<TagResource>>(apiResponse);

                return tags;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        public Task<TagViewModel> GetTagById(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<TagResource> CreateTag(TagResource tag) 
        {
            try
            {
                var obj = JsonConvert.SerializeObject(tag);
                var stringContent = new StringContent(obj, UnicodeEncoding.UTF8, MediaTypeNames.Application.Json);
                var response = await _httpClient.PostAsync(tagsUrl, stringContent);
                string apiResponse = await response.Content.ReadAsStringAsync();
                var createdTag = JsonConvert.DeserializeObject<TagResource>(apiResponse);

                return createdTag;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
      public async Task<List<Tuple<int, string, int>>> GetTagsByOccurancesAndLinkIdAsync(int linkId)
        {
            try
            {
                var response = await _httpClient.GetAsync(tagsUrl + "/gettagsbyOccurancesAndLinkid/" + linkId);
                string apiResponse = await response.Content.ReadAsStringAsync();
                var tags = JsonConvert.DeserializeObject<List<Tuple<int, string, int>>>(apiResponse);

                return tags;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        [HttpGet]
        public async Task<TagResource> CheckTagForOccuranceAsync(string url, string tagname)
        {
            try
            {
                var querystring = System.Web.HttpUtility.UrlEncode(url);
                var response = await _httpClient.GetAsync(tagsUrl + "/checkforoccurance/" + url + "/" + tagname);
                string apiResponse = await response.Content.ReadAsStringAsync();
                var tag = JsonConvert.DeserializeObject<TagResource>(apiResponse);

                return tag;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
