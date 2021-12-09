using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using OnboardingSoftware.Web.Interfaces;
using OnboardingSoftware.Web.Models;
using OnboardingSoftware.Web.Resources;
using static OnboardingSoftware.Web.Settings;

namespace OnboardingSoftware.Web.Services
{
    public class LinkService : ILinkService
    {
        public HttpClient _httpClient { get; set; }
        private string linksUrl;
        public LinkService(IHttpClientFactory httpClientFactory, ApiEndpoint apiEndpoint)
        {
            _httpClient = httpClientFactory.CreateClient();
            linksUrl = apiEndpoint.LinksEndpointUrl;
            _httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue(JwtBearerDefaults.AuthenticationScheme, jwtToken);
        }
        [HttpGet]
        public async Task<IEnumerable<AplikantViewModel>> GetLinks(string userId)
        {
            try
            {
                List<AplikantViewModel> links = new List<AplikantViewModel>();
                //if (!String.IsNullOrEmpty(userId))
                //{
                //    var response = await _httpClient.GetAsync(linksUrl);
                //    string apiResponse = await response.Content.ReadAsStringAsync();
                //    links = JsonConvert.DeserializeObject<List<LinkViewModel>>(apiResponse);
                //}

                links.Add(new AplikantViewModel { ID = 1, Ime = "Damir", Prezime = "Krkalic", 
                    Adresa = "Sarajevo, Federation of Bosnia and Herzegovina", 
                    BrojTelefona = "+38762173906", 
                    DatumRodjenja = "09.05.1996", Email = "damirkrkalic11@gmail.com", 
                    MjestoRodjenja = "Sarajevo, Federation of Bosnia and Herzegovina" });

                links.Add(new AplikantViewModel
                {
                    ID = 1,
                    Ime = "Damir",
                    Prezime = "Krkalic",
                    Adresa = "Sarajevo, Federation of Bosnia and Herzegovina",
                    BrojTelefona = "+38762173906",
                    DatumRodjenja = "09.05.1996",
                    Email = "damirkrkalic11+1@gmail.com",
                    MjestoRodjenja = "Sarajevo, Federation of Bosnia and Herzegovina"
                });

                links.Add(new AplikantViewModel
                {
                    ID = 1,
                    Ime = "Damir",
                    Prezime = "Krkalic",
                    Adresa = "Sarajevo, Federation of Bosnia and Herzegovina",
                    BrojTelefona = "+38762173906",
                    DatumRodjenja = "09.05.1996",
                    Email = "damirkrkalic11+2@gmail.com",
                    MjestoRodjenja = "Sarajevo, Federation of Bosnia and Herzegovina"
                });

                links.Add(new AplikantViewModel
                {
                    ID = 1,
                    Ime = "Damir",
                    Prezime = "Krkalic",
                    Adresa = "Sarajevo, Federation of Bosnia and Herzegovina",
                    BrojTelefona = "+38762173906",
                    DatumRodjenja = "09.05.1996",
                    Email = "damirkrkalic11+3@gmail.com",
                    MjestoRodjenja = "Sarajevo, Federation of Bosnia and Herzegovina"
                });

                return links;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IEnumerable<PosaoViewModel>> GetJobs(string userId)
        {
            try
            {
                List<PosaoViewModel> jobs = new List<PosaoViewModel>();
                //if (!String.IsNullOrEmpty(userId))
                //{
                //    var response = await _httpClient.GetAsync(linksUrl);
                //    string apiResponse = await response.Content.ReadAsStringAsync();
                //    links = JsonConvert.DeserializeObject<List<LinkViewModel>>(apiResponse);
                //}

                jobs.Add(new PosaoViewModel
                {
                    ID = "1",
                    Naziv = "Back-end developer",
                    Kategorija = "Fulltime",
                    Lokacija = "Sarajevo, Federation of Bosnia and Herzegovina",
                    Opis = "N/A",
                    Tip = "Contract · Mid-Senior Level"
                });

                jobs.Add(new PosaoViewModel
                {
                    ID = "2",
                    Naziv = "Back-end developer",
                    Kategorija = "Fulltime",
                    Lokacija = "Sarajevo, Federation of Bosnia and Herzegovina",
                    Opis = "N/A",
                    Tip = "Contract · Mid-Senior Level"
                });

                jobs.Add(new PosaoViewModel
                {
                    ID = "3",
                    Naziv = "Back-end developer",
                    Kategorija = "Fulltime",
                    Lokacija = "Sarajevo, Federation of Bosnia and Herzegovina",
                    Opis = "N/A",
                    Tip = "Contract · Mid-Senior Level"
                });

                jobs.Add(new PosaoViewModel
                {
                    ID = "4",
                    Naziv = "Back-end developer",
                    Kategorija = "Fulltime",
                    Lokacija = "Sarajevo, Federation of Bosnia and Herzegovina",
                    Opis = "N/A",
                    Tip = "Contract · Mid-Senior Level"
                });

                return jobs;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IEnumerable<TestViewModel>> GetTests(string userId)
        {
            try
            {
                List<TestViewModel> tests = new List<TestViewModel>();
                //if (!String.IsNullOrEmpty(userId))
                //{
                //    var response = await _httpClient.GetAsync(linksUrl);
                //    string apiResponse = await response.Content.ReadAsStringAsync();
                //    links = JsonConvert.DeserializeObject<List<LinkViewModel>>(apiResponse);
                //}

                tests.Add(new TestViewModel
                {
                    ID = "1",
                    Naziv = "Cognitive",
                    BrojPitanja = "20",
                    Trajanje = "60min",
                    Tip = "N/A"
                });

                tests.Add(new TestViewModel
                {
                    ID = "2",
                    Naziv = "Personality",
                    BrojPitanja = "20",
                    Trajanje = "60min",
                    Tip = "N/A"
                });

                tests.Add(new TestViewModel
                {
                    ID = "3",
                    Naziv = "Integrity",
                    BrojPitanja = "20",
                    Trajanje = "60min",
                    Tip = "N/A"
                });

                tests.Add(new TestViewModel
                {
                    ID = "4",
                    Naziv = "e-Intelligence",
                    BrojPitanja = "20",
                    Trajanje = "60min",
                    Tip = "N/A"
                });

                return tests;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IEnumerable<PitanjeViewModel>> GetQuestions(string userId)
        {
            try
            {
                List<PitanjeViewModel> questions = new List<PitanjeViewModel>();
                //if (!String.IsNullOrEmpty(userId))
                //{
                //    var response = await _httpClient.GetAsync(linksUrl);
                //    string apiResponse = await response.Content.ReadAsStringAsync();
                //    links = JsonConvert.DeserializeObject<List<LinkViewModel>>(apiResponse);
                //}

                questions.Add(new PitanjeViewModel
                {
                    ID = 1,
                    Tekst = "Question_1",
                    RedniBroj = "No.1",
                    Tip = "Cognitive"
                });

                questions.Add(new PitanjeViewModel
                {
                    ID = 2,
                    Tekst = "Question_2",
                    RedniBroj = "No.2",
                    Tip = "Cognitive"
                });

                questions.Add(new PitanjeViewModel
                {
                    ID = 3,
                    Tekst = "Question_3",
                    RedniBroj = "No.3",
                    Tip = "Cognitive"
                });

                questions.Add(new PitanjeViewModel
                {
                    ID = 4,
                    Tekst = "Question_4",
                    RedniBroj = "No.4",
                    Tip = "Cognitive"
                });

                return questions;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }




        [HttpGet]
        public async Task<LinkResource> CheckLinkForOccurance(string name)
        {
            try
            {
                var querystring = System.Web.HttpUtility.UrlEncode(name);
                var response = await _httpClient.GetAsync(linksUrl + "/checkforoccurance/" + querystring);
                string apiResponse = await response.Content.ReadAsStringAsync();
                var link = JsonConvert.DeserializeObject<LinkResource>(apiResponse);

                return link;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPost]
        public async Task<bool> CreateLink(LinkResource link)
        {
            try
            {
                link.UserId = userId;
                var obj = JsonConvert.SerializeObject(link);
                var stringContent = new StringContent(obj, UnicodeEncoding.UTF8, MediaTypeNames.Application.Json);

                var response = await _httpClient.PostAsync(linksUrl, stringContent);

                //if (response.StatusCode == HttpStatusCode.Conflict)
                //{
                //    var errmsg = JsonConvert.DeserializeObject<dynamic>(response.Content.ReadAsStringAsync().Result);
                //    var id = Regex.Match(Convert.ToString(errmsg), @"'([^']*)").Groups[1].Value;
                //    return new LinkResource { ID = Convert.ToInt32(id), Name = link.Name };
                //}

                //string apiResponse = await response.Content.ReadAsStringAsync();
                //var createdLink = JsonConvert.DeserializeObject<LinkResource>(apiResponse);

                //return createdLink;

                return response.IsSuccessStatusCode;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public Task<LinkViewModel> GetLinkById(int id)
        {
            throw new NotImplementedException();
        }
        public Task<LinkViewModel> CreateLink(LinkViewModel link)
        {
            throw new NotImplementedException();
        }
    }
}

