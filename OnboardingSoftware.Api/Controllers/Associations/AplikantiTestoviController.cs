using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnboardingSoftware.Api.Resources;
using OnboardingSoftware.Core.Models;
using OnboardingSoftware.Core.Services;
using OnboardingSoftware.Core.Services.Associations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnboardingSoftware.Api.Controllers.Associations
{
    [Route("api/[controller]")]
    [ApiController]
    public class AplikantiTestoviController : ControllerBase
    {
        private readonly IAplikantTestService _aplikantTestService;
        private readonly IAplikantService _aplikantService;
        private readonly IMapper _mapper;
        public AplikantiTestoviController(IAplikantTestService aplikantTestService, IAplikantService aplikantService, IMapper mapper)
        {
            this._aplikantService = aplikantService;
            this._aplikantTestService = aplikantTestService;
            this._mapper = mapper;
        }

        // POST: api/aplikantiTestovi
        [HttpPost("")]
        public async Task<ActionResult<bool>> CreateAplikantTest([FromBody] SaveAplikantTestResource saveAplikantTestResource)
        {
            var aplikant = await _aplikantService.GetAplikantByEmail(saveAplikantTestResource.Email);
            if (aplikant == null)
                return NotFound(false);

            saveAplikantTestResource.AplikantID = aplikant.ID;

            var aplikantTestToCreate = _mapper.Map<SaveAplikantTestResource, AplikantTest>(saveAplikantTestResource);
            await _aplikantTestService.CreateAplikantTest(aplikantTestToCreate);

            return Ok(true);
        }

        [HttpGet("")]
        public async Task<ActionResult<AplikantiTestResource>> GetAllAplikantiTest(int testId)
        {
            var aplikantiTest = await _aplikantTestService.GetApplicantsTest(testId);
            var aplikantiTestResource = _mapper.Map<IEnumerable<AplikantTest>, AplikantiTestResource>(aplikantiTest);

            return Ok(aplikantiTestResource);
        }

    }
}
