using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using StopWord;
using OnboardingSoftware.Web.Extensions;
using OnboardingSoftware.Web.Interfaces;
using OnboardingSoftware.Web.Models;
using OnboardingSoftware.Web.Models.Auth;
using OnboardingSoftware.Web.Resources;
using static OnboardingSoftware.Web.Settings;

namespace OnboardingSoftware.Web.Controllers
{
    public class HomeController : Controller
    {
        public ILinkService _linkService { get; private set; }
        public ITagService _tagService { get; private set; }
        public IAuthService _authService { get; private set; }

        public HomeController(IAuthService authService, ITagService tagService, ILinkService linkService)
        {
            _tagService = tagService;
            _authService = authService;
            _linkService = linkService;
        }
        [HttpGet]
        public async Task<IActionResult> Applicants()
        {
            var links = await _linkService.GetLinks(userId);
            return View(links);
        }
        [HttpGet]
        public async Task<IActionResult> Jobs()
        {
            var jobs = await _linkService.GetJobs(userId);
            return View(jobs);
        }
        [HttpGet]
        public async Task<IActionResult> Tests()
        {
            var links = await _linkService.GetTests(userId);
            return View(links);
        }
        [HttpGet]
        public async Task<IActionResult> Questions()
        {
            var links = await _linkService.GetQuestions(userId);
            return View(links);
        }
        [HttpGet]
        public async Task<IActionResult> Tag()
        {
            var tags = await _tagService.GetTags();
            return View(tags);
        }
        [HttpGet]
        public async Task<IActionResult> TagsByLink(int linkId)
        {
            var tags = await _tagService.GetTagsByLinkId(linkId);
            return View("Tags", tags);
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            //if (!ModelState.IsValid)
            //{
            //    return RedirectToAction("Login");
            //}
            //var result = await _authService.Login(model);
            //if (!result)
            //{
            //    return RedirectToAction("Login");
            //}
            return RedirectToAction("Applicants");
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            //if (!ModelState.IsValid)
            //    return RedirectToAction("Register");
            //var result = await _authService.Register(model);
            //if (!result)
            //{
            //    return RedirectToAction("Register");
            //}
            //return RedirectToAction("Login");
            return RedirectToAction("Applicants");
        }
        public async Task<ActionResult> CreateJob([Bind("Naziv, Tip, Kategorija, Opis, Lokacija")] PosaoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _linkService.CreateJob(model);
                if (!response)
                {
                    ViewBag.ErrorMessage = errorMsg;
                    return View(model);
                }
            }
            else
            {
                ViewBag.ErrorMessage = errorMsg;
            }

            return RedirectToAction("Jobs");
        }

        public async Task<ActionResult> CreateTest([Bind("Naziv, Tip, Trajanje, BrojPitanja")] TestViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _linkService.CreateTest(model);
                if (!response)
                {
                    ViewBag.ErrorMessage = errorMsg;
                    return View(model);
                }
            }
            else
            {
                ViewBag.ErrorMessage = errorMsg;
            }

            return RedirectToAction("Tests");
        }


        public async Task<ActionResult> CreateQuestion([Bind("Tekst, Tip, RedniBroj, SelectedTag, TagResources")] PitanjeViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.TestID = Convert.ToInt32(model.SelectedTag); //validate
                var response = await _linkService.CreateQuestion(model);
                if (!response)
                {
                    ViewBag.ErrorMessage = errorMsg;
                    return View(model);
                }
            }
            else
            {
                ViewBag.ErrorMessage = errorMsg;
            }

            return RedirectToAction("Questions");
        }



        //if (!String.IsNullOrEmpty(model.Name))
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (String.IsNullOrEmpty(model.SelectedTag) || model.SelectedTag == "Add other" || model.SelectedTag == "Select tag category")
        //        {
        //            ViewBag.ErrorMessage = errorMsgGen;
        //            return View(model);
        //        }

        //        //check for tag occurance
        //        // var selectedTagExists = await _tagService.CheckTagForOccuranceAsync(model.Name, model.SelectedTag);
        //        model.Name = model.Name.ToLower();
        //        var response = await _linkService.CreateLink(model);
        //        if (!response)
        //        {
        //            ViewBag.ErrorMessage = errorMsg;
        //            return View(model);
        //        }
        //        return RedirectToAction("Home");
        //    }
        //    else
        //    {
        //        model.TagResources.Clear();
        //        ViewBag.ErrorMessage = errorMsg;
        //    }
        //}

        //  return View(model);
        // }
























       // public async Task<ActionResult> CreateQuestion(PitanjeViewModel model)
       // {

          //  return View(model);
       // }

        //public async Task<ActionResult> CreateTest(TestViewModel model)
        //{

        //    return View(model);
        //}

        protected List<TagResource> StripHtml(LinkResource link)
        {
            string siteContent = string.Empty;
            try
            {
                List<TagResource> tagResourcesForSuggestion = new List<TagResource>();

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(link.Name);
                request.AutomaticDecompression = DecompressionMethods.GZip;

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream responseStream = response.GetResponseStream())
                using (StreamReader streamReader = new StreamReader(responseStream))
                {
                    siteContent = streamReader.ReadToEnd();
                }

                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.OptionWriteEmptyNodes = true;
                doc.LoadHtml(siteContent);
                if (doc == null) return null;
                string output = "";
                foreach (var node in doc.DocumentNode.ChildNodes)
                {
                    output += node.InnerText;
                }
                var result = output.RemoveStopWords("en");
                result = result.RemoveSpecialCharacters();
                string[] splitkeywords = Regex.Split(result, "(?<=[a-z])(?=[A-Z])|(?<=[0-9])(?=[A-Za-z])|(?<=[A-Za-z])(?=[0-9])|(?<=\\W)(?=\\W)");
                splitkeywords = (from x in splitkeywords select x.Trim()).ToArray();

                var longwords = String.Join(" ", splitkeywords.Where(x => x.Length > 3).ToArray());
                var splitlongwords = longwords.Split(" ");

                var groupedkeywords = splitlongwords.GroupBy(split => split)
                    .Select(g => new { Keyword = g.Key, Count = g.Count() });

                var sortedkeywords = groupedkeywords.OrderByDescending(x => x.Count).ThenBy(X => X.Keyword).ToList();

                var count = sortedkeywords.Count() > 10 ? 10 : sortedkeywords.Count() - 1;

                foreach (var item in sortedkeywords.GetRange(0, count)) //temporary
                {
                    if (item.Count > 2)
                    {
                        for (int i = 0; i < item.Count; i++)
                        {
                            tagResourcesForSuggestion.Add(new TagResource { Name = item.Keyword, LinkId = link.ID });
                        }
                        //tagResourcesForSuggestion.Add(new TagResource { Name = item.Keyword, NumberOfOccurances = "Occured " + item.Count + " times.", LinkId = link.ID });
                    }

                }

                return tagResourcesForSuggestion;
            }
            catch (Exception)
            {
                return null; //not possible to parse the provided URL
            }
        }
        public async Task<ActionResult> InitializeTags([Bind("Name, SelectedTag, TagResources")] PitanjeViewModel model)
        {
            //model.NewTagResources.Clear();
            //model.TagResources.Clear();
            //suggest tags from other users
            var linkOccurance = await _linkService.GetTests(userId); //check if user adds same link twice firstly
            //if (linkOccurance != null)
            //{
            //    var tagsWithOccurances = await _tagService.GetTagsByOccurancesAndLinkIdAsync(linkOccurance.ID);
            //    var usertags = await _tagService.GetTagsByLinkId(linkOccurance.ID);
            //    if (tagsWithOccurances != null && tagsWithOccurances.Any())
            //    {
            //        //model.TagResources = new List<TagResource>();
            //        foreach (var item in tagsWithOccurances)
            //        {
            //            bool exists = false;
            //             model.TagResources.Add(new SelectListItem() { Disabled=true, Text = item.Item2, Value = item.Item1.ToString()});

            //            //foreach (var ex in usertags)
            //            //{
            //            //    if (item.Item1 == ex.ID)
            //            //    {
            //            //        model.TagResources.Add(new SelectListItem() { Disabled = true, Text = item.Item2, Value = item.Item2 });
            //            //        exists = true;
            //            //        break;
            //            //    }
            //            //}
            //            //if (!exists)
            //            //    model.TagResources.Add(new SelectListItem() { Text = item.Item2, Value = item.Item2 });
            //            //if (item.Item2 == 1)
            //            //    model.TagResources.Add(new TagResource { Name = item.Item1, NumberOfOccurances = "Occured once.", LinkId = model.ID });
            //            //else
            //            //    model.TagResources.Add(new TagResource { Name = item.Item1, NumberOfOccurances = "Occured " + item.Item2 + " times.", LinkId = model.ID });
            //        }
            //    }
            //}

            foreach (var item in linkOccurance)
            {
                model.TagResources.Insert(0, new SelectListItem { Text = item.Naziv, Value = item.ID });
            }

            //model.TagResources.Insert(0, new SelectListItem { Text = "Select tag category", Value = "0" });
            //model.TagResources.Insert(model.TagResources.Count, new SelectListItem { Text = "Add other", Value = "Add other" });
            //model.SelectedTag = "0";

            // suggest for new tags from content
            //var contentTags = StripHtml(model);
            //if (contentTags != null && contentTags.Any())
            //{
            //    var grouped = contentTags.GroupBy(x => x.Name)
            //    .OrderBy(group => group.Key)
            //    .Select(group => Tuple.Create(group.Key, group.Count()))
            //    .ToList();

            //    var sorted = grouped.OrderByDescending(x => x.Item2).ThenBy(X => X.Item1).ToList();

            //    int i = 0;
            //    foreach (var item in sorted)
            //    {
            //        i++;
            //        //item.LinkId = model.ID;
            //        // model.TagResources.Add(new TagResource { Name = item.Item1, NumberOfOccurances = "Occured " + item.Item2 + " times.", LinkId = model.ID });
            //        model.NewTagResources.Add(new SelectListItem() { Text = item.Item1, Value = i + ". " }); //name - both times?
            //    }

            //}

            // model.TagResources.Add(new TagResource());

            return PartialView("TagRow", model);
        }

        public async Task<ActionResult> AddTag([Bind("Name, SelectedTag, TagResources")] PitanjeViewModel model)
        {
            //   model.TagResources.Add(new TagResource());
           // model.TagResources.Insert(0, new SelectListItem { Text = item.Naziv, Value = item.ID });
            return PartialView("TagRow", model);
        }
        public async Task<ActionResult> ClearTags([Bind("Name,SelectedTag, TagResources")] LinkResource model)
        {
            if (model.TagResources != null)
                model.TagResources.Clear();

            return View("TagRow", model);
        }
        public ActionResult Logout()
        {
            userId = String.Empty;
            return View("Login");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
