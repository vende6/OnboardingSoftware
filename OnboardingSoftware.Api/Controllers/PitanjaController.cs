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
    public class PitanjaController : ControllerBase
    {
        private readonly IPitanjeService _pitanjeService;
        private readonly IOdgovorService _odgovorService;
        private readonly IMapper _mapper;
        public PitanjaController(IPitanjeService pitanjeService, IOdgovorService odgovorService, IMapper mapper)
        {
            this._pitanjeService = pitanjeService;
            this._odgovorService = odgovorService;
            this._mapper = mapper;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<PitanjeResource>>> GetAllPitanja()
        {
            var pitanja = await this._pitanjeService.GetPitanja();
            var pitanjaResources = _mapper.Map<IEnumerable<Pitanje>, IEnumerable<PitanjeResource>>(pitanja);

            return Ok(pitanjaResources);
        }

        [HttpGet("{testId}", Name = "GetPitanjaByTestId")]
        public async Task<ActionResult<PitanjeResource>> GetPitanjaByTestId(int testId)
        {
            var pitanja = await _pitanjeService.GetPitanjaByTestId(testId);
            if (pitanja == null)
                return NotFound();
            var pitanjaResource = _mapper.Map<IEnumerable<Pitanje>, IEnumerable<PitanjeResource>>(pitanja);

            foreach (var item in pitanjaResource)
            {
                var odgovori = await _odgovorService.GetOdgovoriByPitanjeId(item.ID);
                var odgovoriResource = _mapper.Map<IEnumerable<Odgovor>, IEnumerable<OdgovorResource>>(odgovori);

                item.Odgovori = odgovoriResource.Cast<OdgovorResource>();
               
            }

            return Ok(pitanjaResource);
        }

        // POST: api/pitanja
        [HttpPost("")]
        public async Task<ActionResult<bool>> CreatePitanje([FromBody] SavePitanjeResource pitanjeResource)
        {

            //var validator = new SaveLinkResourceValidator();
            //var validationResult = await validator.ValidateAsync(saveLinkResource);
            //if (!validationResult.IsValid)
            //    return BadRequest(validationResult.Errors);

            var pitanje = _mapper.Map<SavePitanjeResource, Pitanje>(pitanjeResource);
            await _pitanjeService.CreatePitanje(pitanje);


            //await _userLinkService.CreateUserLink(new UserLink { LinkId = link.ID, TagId = tag.ID, UserId = Guid.Parse(userId) });

            return Ok(true);
        }

    }
}
