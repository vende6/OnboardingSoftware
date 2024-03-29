﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
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
        private string aplikantiUrl;
        private string jobsUrl;
        private string testsUrl;
        private string questionsUrl;
        private string answersUrl;
        public LinkService(IHttpClientFactory httpClientFactory, ApiEndpoint apiEndpoint)
        {
            _httpClient = httpClientFactory.CreateClient();
            aplikantiUrl = apiEndpoint.AplikantiEndpointUrl;
            jobsUrl = apiEndpoint.JobsEndpointUrl;
            testsUrl = apiEndpoint.TestsEndpointUrl;
            questionsUrl = apiEndpoint.QuestionsEndpointUrl;
            answersUrl = apiEndpoint.AnswersEndpointUrl;

            _httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue(JwtBearerDefaults.AuthenticationScheme, jwtToken);
        }
        [HttpGet]
        public async Task<IEnumerable<AplikantViewModel>> GetLinks(string userId)
        {
            try
            {
                List<AplikantViewModel> links = new List<AplikantViewModel>();
               // if (!String.IsNullOrEmpty(userId))
               // {
                    var response = await _httpClient.GetAsync(aplikantiUrl);
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    links = JsonConvert.DeserializeObject<List<AplikantViewModel>>(apiResponse);
              //  }

                //links.Add(new AplikantViewModel { ID = 1, Ime = "Damir", Prezime = "Krkalic", 
                //    Adresa = "Sarajevo, Federation of Bosnia and Herzegovina", 
                //    BrojTelefona = "+387 62 173 906", 
                //    DatumRodjenja = "09/05/1996", Email = "damir.krkalic@edu.fit.ba", 
                //    MjestoRodjenja = "Sarajevo, Federation of Bosnia and Herzegovina" });

                //  links.Add(new AplikantViewModel { ID = 1, Ime = "Damir", Prezime = "Krkalic", 
                //    Adresa = "Sarajevo, Federation of Bosnia and Herzegovina", 
                //    BrojTelefona = "+387 62 173 906", 
                //    DatumRodjenja = "09/05/1996", Email = "damir.krkalic@edu.fit.ba", 
                //    MjestoRodjenja = "Sarajevo, Federation of Bosnia and Herzegovina" });

                //  links.Add(new AplikantViewModel { ID = 1, Ime = "Damir", Prezime = "Krkalic", 
                //    Adresa = "Sarajevo, Federation of Bosnia and Herzegovina", 
                //    BrojTelefona = "+387 62 173 906", 
                //    DatumRodjenja = "09/05/1996", Email = "damir.krkalic@edu.fit.ba", 
                //    MjestoRodjenja = "Sarajevo, Federation of Bosnia and Herzegovina" });

                //  links.Add(new AplikantViewModel { ID = 1, Ime = "Damir", Prezime = "Krkalic", 
                //    Adresa = "Sarajevo, Federation of Bosnia and Herzegovina", 
                //    BrojTelefona = "+387 62 173 906", 
                //    DatumRodjenja = "09/05/1996", Email = "damir.krkalic@edu.fit.ba", 
                //    MjestoRodjenja = "Sarajevo, Federation of Bosnia and Herzegovina" });
            

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
                    var response = await _httpClient.GetAsync(jobsUrl);
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    jobs = JsonConvert.DeserializeObject<List<PosaoViewModel>>(apiResponse);
                //}

                //jobs.Add(new PosaoViewModel
                //{
                //    ID = "1",
                //    Naziv = "Back-end developer",
                //    Kategorija = "Fulltime",
                //    Lokacija = "Sarajevo, Federation of Bosnia and Herzegovina",
                //    Opis = "N/A",
                //    Tip = "Contract · Mid-Senior Level"
                //});

                //jobs.Add(new PosaoViewModel
                //{
                //    ID = "2",
                //    Naziv = "Back-end developer",
                //    Kategorija = "Fulltime",
                //    Lokacija = "Sarajevo, Federation of Bosnia and Herzegovina",
                //    Opis = "N/A",
                //    Tip = "Contract · Mid-Senior Level"
                //});

                //jobs.Add(new PosaoViewModel
                //{
                //    ID = "3",
                //    Naziv = "Back-end developer",
                //    Kategorija = "Fulltime",
                //    Lokacija = "Sarajevo, Federation of Bosnia and Herzegovina",
                //    Opis = "N/A",
                //    Tip = "Contract · Mid-Senior Level"
                //});

                //jobs.Add(new PosaoViewModel
                //{
                //    ID = "4",
                //    Naziv = "Back-end developer",
                //    Kategorija = "Fulltime",
                //    Lokacija = "Sarajevo, Federation of Bosnia and Herzegovina",
                //    Opis = "N/A",
                //    Tip = "Contract · Mid-Senior Level"
                //});

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
               // if (!String.IsNullOrEmpty(userId))
               // {
                    var response = await _httpClient.GetAsync(testsUrl);
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    tests = JsonConvert.DeserializeObject<List<TestViewModel>>(apiResponse);
              //  }

                //tests.Add(new TestViewModel
                //{
                //    ID = "1",
                //    Naziv = "Cognitive",
                //    BrojPitanja = "2",
                //    Trajanje = "2min",
                //    Tip = "N/A"
                //});

                //tests.Add(new TestViewModel
                //{
                //    ID = "2",
                //    Naziv = "Personality",
                //    BrojPitanja = "2",
                //    Trajanje = "2min",
                //    Tip = "N/A"
                //});

                //tests.Add(new TestViewModel
                //{
                //    ID = "3",
                //    Naziv = "Integrity",
                //    BrojPitanja = "2",
                //    Trajanje = "2min",
                //    Tip = "N/A"
                //});

                //tests.Add(new TestViewModel
                //{
                //    ID = "4",
                //    Naziv = "e-Intelligence",
                //    BrojPitanja = "2",
                //    Trajanje = "2min",
                //    Tip = "N/A"
                //});

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
                var response = await _httpClient.GetAsync(questionsUrl);
                string apiResponse = await response.Content.ReadAsStringAsync();
                questions = JsonConvert.DeserializeObject<List<PitanjeViewModel>>(apiResponse);
                //}

                //questions.Add(new PitanjeViewModel
                //{
                //    ID = 1,
                //    Tekst = "Question?",
                //    RedniBroj = "No.1",
                //    Tip = "Cognitive"
                //});

                //questions.Add(new PitanjeViewModel
                //{
                //    ID = 2,
                //    Tekst = "Question?",
                //    RedniBroj = "No.2",
                //    Tip = "Cognitive"
                //});

                //questions.Add(new PitanjeViewModel
                //{
                //    ID = 3,
                //    Tekst = "Question?",
                //    RedniBroj = "No.1",
                //    Tip = "Cognitive"
                //});

                //questions.Add(new PitanjeViewModel
                //{
                //    ID = 4,
                //    Tekst = "Question?",
                //    RedniBroj = "No.2",
                //    Tip = "Cognitive"
                //});

                return questions;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IEnumerable<OdgovorViewModel>> GetAnswers(string userId)
        {
            try
            {
                List<OdgovorViewModel> answers = new List<OdgovorViewModel>();
                //if (!String.IsNullOrEmpty(userId))
                //{
                var response = await _httpClient.GetAsync(answersUrl);
                string apiResponse = await response.Content.ReadAsStringAsync();
                answers = JsonConvert.DeserializeObject<List<OdgovorViewModel>>(apiResponse);
                //}

                return answers;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        //[HttpGet]
        //public async Task<LinkResource> CheckLinkForOccurance(string name)
        //{
        //    try
        //    {
        //        var querystring = System.Web.HttpUtility.UrlEncode(name);
        //        var response = await _httpClient.GetAsync(linksUrl + "/checkforoccurance/" + querystring);
        //        string apiResponse = await response.Content.ReadAsStringAsync();
        //        var link = JsonConvert.DeserializeObject<LinkResource>(apiResponse);

        //        return link;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
        [HttpPost]
        public async Task<bool> CreateJob(PosaoViewModel posao)
        {
            try
            {
                SavePosaoResource posaoResource = new SavePosaoResource
                {
                    Naziv = posao.Naziv,
                    Kategorija = posao.Kategorija,
                    Lokacija = new LokacijaResource { Naziv = posao.Lokacija },
                    Opis = posao.Opis,
                    Tip = posao.Tip
                };

                var obj = JsonConvert.SerializeObject(posaoResource);
                var stringContent = new StringContent(obj, UnicodeEncoding.UTF8, MediaTypeNames.Application.Json);

                var response = await _httpClient.PostAsync(jobsUrl, stringContent);

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

        [HttpPost]
        public async Task<bool> CreateTest(TestViewModel test)
        {
            try
            {
                SaveTestResource testResource = new SaveTestResource
                {
                    Naziv = test.Naziv,
                    Tip = test.Tip,
                    Trajanje = test.Trajanje,
                    BrojPitanja = test.BrojPitanja,
                    OsvojeniProcenat="N/A",
                    Pocetak=DateTime.Now,
                    Kraj=DateTime.Now.AddMinutes(2)
                };

                var obj = JsonConvert.SerializeObject(testResource);
                var stringContent = new StringContent(obj, UnicodeEncoding.UTF8, MediaTypeNames.Application.Json);

                var response = await _httpClient.PostAsync(testsUrl, stringContent);

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

        [HttpPost]
        public async Task<bool> CreateQuestion(PitanjeViewModel pitanje)
        {
            try
            {

                var obj = JsonConvert.SerializeObject(pitanje);
                var stringContent = new StringContent(obj, UnicodeEncoding.UTF8, MediaTypeNames.Application.Json);

                var response = await _httpClient.PostAsync(questionsUrl, stringContent);

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

        [HttpPost]
        public async Task<bool> CreateAnswer(OdgovorViewModel odgovor)
        {
            try
            {
                //if (odgovor.PonudjeniOdgovor_1 == null)
                //    odgovor.PonudjeniOdgovor_1 = "";
                //if (odgovor.PonudjeniOdgovor_2 == null)
                //    odgovor.PonudjeniOdgovor_2 = "";
                //if (odgovor.PonudjeniOdgovor_3 == null)
                //    odgovor.PonudjeniOdgovor_3 = "";
                //if (odgovor.PonudjeniOdgovor_4 == null)
                //    odgovor.PonudjeniOdgovor_4 = "";

                SaveOdgovorResource resource = new SaveOdgovorResource
                {
                    TekstOdgovor = "",
                    PitanjeID = odgovor.PitanjeID,
                    PonudjeniOdgovor_1 = odgovor.PonudjeniOdgovor_1,
                    PonudjeniOdgovor_2 = odgovor.PonudjeniOdgovor_2,
                    PonudjeniOdgovor_3 = odgovor.PonudjeniOdgovor_3,
                    PonudjeniOdgovor_4 = odgovor.PonudjeniOdgovor_4,

                };

                var obj = JsonConvert.SerializeObject(resource);
                var stringContent = new StringContent(obj, UnicodeEncoding.UTF8, MediaTypeNames.Application.Json);

                var response = await _httpClient.PostAsync(answersUrl, stringContent);

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

