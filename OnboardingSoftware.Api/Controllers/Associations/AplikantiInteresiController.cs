using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnboardingSoftware.Api.Resources;
using OnboardingSoftware.Core.Models;
using OnboardingSoftware.Core.Services.Associations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnboardingSoftware.Api.Controllers.Associations
{
    [Route("api/[controller]")]
    [ApiController]
    public class AplikantiInteresiController : ControllerBase
    {
        private readonly IAplikantInteresService _aplikantInteresService;
        private readonly IMapper _mapper;
        public AplikantiInteresiController(IAplikantInteresService aplikantInteresService, IMapper mapper)
        {
            this._aplikantInteresService = aplikantInteresService;
            this._mapper = mapper;
        }

        // POST: api/aplikantiInteresi
        [HttpPost("")]
        public async Task<ActionResult<bool>> CreateAplikantInteres([FromBody] SaveAplikantInteresResource saveAplikantInteresResource)
        {

            var aplikantInteresToCreate = _mapper.Map<SaveAplikantInteresResource, AplikantInteres>(saveAplikantInteresResource);
            await _aplikantInteresService.CreateAplikantInteres(aplikantInteresToCreate);

            return Ok(true);
        }

        [HttpGet("")]
        public async Task<ActionResult<AplikantInteresiResource>> GetAllAplikantInteresi(int aplikantId)
        {
            var aplikantInteresi = await _aplikantInteresService.GetApplicantInterests(aplikantId);
            var aplikantInteresiResource = _mapper.Map<IEnumerable<AplikantInteres>, AplikantInteresiResource>(aplikantInteresi);

            return Ok(aplikantInteresiResource);
        }

    }
}
