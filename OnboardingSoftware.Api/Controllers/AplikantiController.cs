using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnboardingSoftware.Api.Resources;
using OnboardingSoftware.Core.Models;
using OnboardingSoftware.Core.Services;
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
        public AplikantiController(IAplikantService aplikantService, IMapper mapper)
        {
            this._aplikantService = aplikantService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<AplikantResource>>> GetAllAplikanti()
        {
            //var aplikanti = await this._aplikantService.GetAllWithVjestine();

            List<AplikantResource> aplikants = new List<AplikantResource>();

            aplikants.Add(new AplikantResource
            {
                ID = 1,
                Ime = "Damir",
                Prezime = "Krkalic",
                Adresa = "Sarajevo, Federation of Bosnia and Herzegovina",
                BrojTelefona = "+387 62 173 906",
                DatumRodjenja = Convert.ToDateTime("09/05/1996"),
                Email = "damir.krkalic@edu.fit.ba",
                MjestoRodjenja = "Sarajevo, Federation of Bosnia and Herzegovina"
            });

            aplikants.Add(new AplikantResource
            {
                ID = 1,
                Ime = "Damir",
                Prezime = "Krkalic",
                Adresa = "Sarajevo, Federation of Bosnia and Herzegovina",
                BrojTelefona = "+387 62 173 906",
                DatumRodjenja = Convert.ToDateTime("09/05/1996"),
                Email = "damir.krkalic@edu.fit.ba",
                MjestoRodjenja = "Sarajevo, Federation of Bosnia and Herzegovina"
            });

            aplikants.Add(new AplikantResource
            {
                ID = 1,
                Ime = "Damir",
                Prezime = "Krkalic",
                Adresa = "Sarajevo, Federation of Bosnia and Herzegovina",
                BrojTelefona = "+387 62 173 906",
                DatumRodjenja = Convert.ToDateTime("09/05/1996"),
                Email = "damir.krkalic@edu.fit.ba",
                MjestoRodjenja = "Sarajevo, Federation of Bosnia and Herzegovina"
            });

            aplikants.Add(new AplikantResource
            {
                ID = 1,
                Ime = "Damir",
                Prezime = "Krkalic",
                Adresa = "Sarajevo, Federation of Bosnia and Herzegovina",
                BrojTelefona = "+387 62 173 906",
                DatumRodjenja = Convert.ToDateTime("09/05/1996"),
                Email = "damir.krkalic@edu.fit.ba",
                MjestoRodjenja = "Sarajevo, Federation of Bosnia and Herzegovina"
            });

            return Ok(aplikants);
        }
    }
}
