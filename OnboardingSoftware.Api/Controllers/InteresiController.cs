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
    public class InteresiController : ControllerBase
    {
        private readonly IInteresService _interesService;
        private readonly IMapper _mapper;
        public InteresiController(IInteresService interesService, IMapper mapper)
        {
            this._interesService = interesService;
            this._mapper = mapper;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<InterestResource>>> GetAllInteresi()
        {
            var interesi = await this._interesService.GetInterests();
            var interesResources = _mapper.Map<IEnumerable<Interes>, IEnumerable<InterestResource>>(interesi);

            return Ok(interesResources);
        }

        // POST: api/interesi
        [HttpPost("")]
        public async Task<ActionResult<bool>> CreateInteres([FromBody] SaveInterestResource saveInteresResource)
        {

            var interesToCreate = _mapper.Map<SaveInterestResource, Interes>(saveInteresResource);
            await _interesService.CreateInteres(interesToCreate);

            return Ok(true);
        }

    }
}
