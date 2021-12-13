﻿using AutoMapper;
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
        private readonly IMapper _mapper;
        public PitanjaController(IPitanjeService pitanjeService, IMapper mapper)
        {
            this._pitanjeService = pitanjeService;
            this._mapper = mapper;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<PitanjeResource>>> GetAllPitanja()
        {
            var testovi = await this._pitanjeService.GetPitanja();
            var testResources = _mapper.Map<IEnumerable<Pitanje>, IEnumerable<PitanjeResource>>(testovi);

            return Ok(testResources);
        }

        // POST: api/poslovi
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
