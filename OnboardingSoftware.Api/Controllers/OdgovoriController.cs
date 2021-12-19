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
    public class OdgovoriController : ControllerBase
    {
        private readonly IOdgovorService _odgovorService;
        private readonly IMapper _mapper;
        public OdgovoriController(IOdgovorService odgovorService, IMapper mapper)
        {
            this._odgovorService = odgovorService;
            this._mapper = mapper;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<OdgovorResource>>> GetAllOdgovori()
        {
            var odgovori = await this._odgovorService.GetOdgovori();
            var odgovoriResources = _mapper.Map<IEnumerable<Odgovor>, IEnumerable<OdgovorResource>>(odgovori);

            return Ok(odgovoriResources);
        }

        [HttpGet("{pitanjeId}", Name = "GetOdgovoriByPitanjeId")]
        public async Task<ActionResult<IEnumerable<OdgovorResource>>> GetOdgovoriByPitanjeId(int pitanjeId)
        {
            var odgovori = await _odgovorService.GetOdgovoriByPitanjeId(pitanjeId);
            if (odgovori == null)
                return NotFound();
            var odgovorResource = _mapper.Map<IEnumerable<Odgovor>, IEnumerable<OdgovorResource>>(odgovori);

            return Ok(odgovorResource);
        }

        // POST: api/odgovori
        [HttpPost("")]
        public async Task<ActionResult<bool>> CreateOdgovor([FromBody] SaveOdgovorResource saveOdgovorResource)
        {

            //var validator = new SaveLinkResourceValidator();
            //var validationResult = await validator.ValidateAsync(saveLinkResource);
            //if (!validationResult.IsValid)
            //    return BadRequest(validationResult.Errors);

            var odgovor = _mapper.Map<SaveOdgovorResource, Odgovor>(saveOdgovorResource);
            await _odgovorService.CreateOdgovor(odgovor);


            //await _userLinkService.CreateUserLink(new UserLink { LinkId = link.ID, TagId = tag.ID, UserId = Guid.Parse(userId) });

            return Ok(true);
        }

        // POST: api/odgovori
        [HttpPut("")]
        public async Task<ActionResult<bool>> UpdateOdgovori([FromBody] UpdateOdgovoriResource updateOdgovoriResource)
        {

            //var validator = new SaveLinkResourceValidator();
            //var validationResult = await validator.ValidateAsync(saveLinkResource);
            //if (!validationResult.IsValid)
            //    return BadRequest(validationResult.Errors);

            var odgovori = _mapper.Map<IEnumerable<OdgovorResource>, IEnumerable<Odgovor>>(updateOdgovoriResource.Odgovori);
            await _odgovorService.UpdateOdgovori(odgovori);


            //await _userLinkService.CreateUserLink(new UserLink { LinkId = link.ID, TagId = tag.ID, UserId = Guid.Parse(userId) });

            return Ok(true);
        }
    }
}
