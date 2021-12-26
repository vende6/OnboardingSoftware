using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnboardingSoftware.Api.Resources;
using OnboardingSoftware.Core.Models;
using OnboardingSoftware.Core.Services;
using OnboardingSoftware.Core.Services.Associations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnboardingSoftware.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AplikantiController : ControllerBase
    {
        private readonly IAplikantService _aplikantService;
        private readonly IAplikantTestService _aplikantTestService;
        private readonly IAplikantPosaoService _aplikantPosaoService;
        private readonly IMapper _mapper;
        public AplikantiController(IAplikantService aplikantService, IAplikantTestService aplikantTestService, IAplikantPosaoService aplikantPosaoService, IMapper mapper)
        {
            this._aplikantService = aplikantService;
            this._aplikantTestService = aplikantTestService;
            this._aplikantPosaoService = aplikantPosaoService;
            this._mapper = mapper;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<AplikantResource>>> GetAllAplikanti()
        {

            var aplikanti = await _aplikantService.GetAll();
            if (aplikanti == null)
                return NotFound();

            var aplikants = _mapper.Map<IEnumerable<Aplikant>, IEnumerable<AplikantResource>>(aplikanti);
            return Ok(aplikants);

        }


        //PUT: api/aplikanti
        [HttpPut("{email}")]
        public async Task<ActionResult<bool>> UpdateAplikant(string email, [FromBody] UpdateAplikantResource updateAplikantResource)
        {

            var aplikant = await _aplikantService.GetAplikantByEmail(email);
            if (aplikant == null)
                return NotFound();


            var aplikantUpdate = _mapper.Map<UpdateAplikantResource, Aplikant>(updateAplikantResource);
            await _aplikantService.UpdateAplikant(aplikant, aplikantUpdate);

            return Ok(true);
        }





        //aplikants.Add(new AplikantResource
        //{
        //    ID = 1,
        //    Ime = "Damir",
        //    Prezime = "Krkalic",
        //    Adresa = "Sarajevo, Federation of Bosnia and Herzegovina",
        //    BrojTelefona = "+387 62 173 906",
        //    DatumRodjenja = Convert.ToDateTime("09/05/1996"),
        //    Email = "damir.krkalic@edu.fit.ba",
        //    MjestoRodjenja = "Sarajevo, Federation of Bosnia and Herzegovina"
        //});

        //aplikants.Add(new AplikantResource
        //{
        //    ID = 1,
        //    Ime = "Damir",
        //    Prezime = "Krkalic",
        //    Adresa = "Sarajevo, Federation of Bosnia and Herzegovina",
        //    BrojTelefona = "+387 62 173 906",
        //    DatumRodjenja = Convert.ToDateTime("09/05/1996"),
        //    Email = "damir.krkalic@edu.fit.ba",
        //    MjestoRodjenja = "Sarajevo, Federation of Bosnia and Herzegovina"
        //});

        //aplikants.Add(new AplikantResource
        //{
        //    ID = 1,
        //    Ime = "Damir",
        //    Prezime = "Krkalic",
        //    Adresa = "Sarajevo, Federation of Bosnia and Herzegovina",
        //    BrojTelefona = "+387 62 173 906",
        //    DatumRodjenja = Convert.ToDateTime("09/05/1996"),
        //    Email = "damir.krkalic@edu.fit.ba",
        //    MjestoRodjenja = "Sarajevo, Federation of Bosnia and Herzegovina"
        //});

        //aplikants.Add(new AplikantResource
        //{
        //    ID = 1,
        //    Ime = "Damir",
        //    Prezime = "Krkalic",
        //    Adresa = "Sarajevo, Federation of Bosnia and Herzegovina",
        //    BrojTelefona = "+387 62 173 906",
        //    DatumRodjenja = Convert.ToDateTime("09/05/1996"),
        //    Email = "damir.krkalic@edu.fit.ba",
        //    MjestoRodjenja = "Sarajevo, Federation of Bosnia and Herzegovina"
        //});

        //[HttpGet("{email}", Name = "GetAplikantByEmail")]
        //public async Task<ActionResult<PosaoResource>> GetAplikantByEmail(string email)
        //{
        //    var aplikant = await _aplikantService.GetAplikantByEmail(email);
        //    if (aplikant == null)
        //        return NotFound();

        //    var aplikantResource = _mapper.Map<Aplikant, AplikantResource>(aplikant);
        //    return Ok(aplikantResource);
        //}

        // POST: api/aplikanti
        //[HttpPost("SaveTest", Name = "SaveTest")]
        //public async Task<ActionResult<bool>> CreateAplikantTest([FromBody] SaveAplikantTestResource saveAplikantTestResource)
        //{

        //    var aplikant = await _aplikantService.GetAplikantByEmail(saveAplikantTestResource.Email);
        //    if (aplikant == null)
        //        return NotFound(false);

        //    saveAplikantTestResource.AplikantID = aplikant.ID;

        //    var aplikantTestToCreate = _mapper.Map<SaveAplikantTestResource, AplikantTest>(saveAplikantTestResource);
        //    await _aplikantTestService.CreateAplikantTest(aplikantTestToCreate);


        //    return Ok(true);
        //}

        //// POST: api/aplikanti
        //[HttpPost("SavePosao", Name = "SavePosao")]
        //public async Task<ActionResult<bool>> CreateAplikantPosao([FromBody] SaveAplikantPosaoResource saveAplikantPosaoResource)
        //{
        //    var aplikant = await _aplikantService.GetAplikantByEmail(saveAplikantPosaoResource.Email);
        //    if (aplikant == null)
        //        return NotFound(false);

        //    saveAplikantPosaoResource.AplikantID = aplikant.ID;

        //    var aplikantPosaoToCreate = _mapper.Map<SaveAplikantPosaoResource, AplikantPosao>(saveAplikantPosaoResource);
        //    await _aplikantPosaoService.CreateAplikantPosao(aplikantPosaoToCreate);


        //    return Ok(true);
        //}            //await _userLinkService.CreateUserLink(new UserLink { LinkId = link.ID, TagId = tag.ID, UserId = Guid.Parse(userId) });
    }
}
