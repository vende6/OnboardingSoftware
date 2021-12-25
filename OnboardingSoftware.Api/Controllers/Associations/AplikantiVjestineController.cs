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
    public class AplikantiVjestineController : ControllerBase
    {
        private readonly IAplikantVjestinaService _aplikantVjestinaService;
        private readonly IAplikantService _aplikantService;
        private readonly IMapper _mapper;
        public AplikantiVjestineController(IAplikantVjestinaService aplikantVjestinaService, IAplikantService aplikantService, IMapper mapper)
        {
            this._aplikantService = aplikantService;
            this._aplikantVjestinaService = aplikantVjestinaService;
            this._mapper = mapper;
        }

        // POST: api/aplikantiInteresi
        [HttpPost("")]
        public async Task<ActionResult<bool>> CreateAplikantVjestina([FromBody] SaveAplikantVjestinaResource saveAplikantVjestinaResource)
        {
            var aplikant = await _aplikantService.GetAplikantByEmail(saveAplikantVjestinaResource.Email);
            if (aplikant == null)
                return NotFound(false);

            saveAplikantVjestinaResource.AplikantID = aplikant.ID;

            var aplikantVjestinaToCreate = _mapper.Map<SaveAplikantVjestinaResource, AplikantVjestina>(saveAplikantVjestinaResource);
            await _aplikantVjestinaService.CreateAplikantVjestina(aplikantVjestinaToCreate);

            return Ok(true);
        }

        [HttpGet("")]
        public async Task<ActionResult<AplikantVjestineResource>> GetAllAplikantVjestine(int aplikantId)
        {
            var aplikantVjestine = await _aplikantVjestinaService.GetApplicantSkills(aplikantId);
            var aplikantVjestineResource = _mapper.Map<IEnumerable<AplikantVjestina>, AplikantVjestineResource>(aplikantVjestine);

            return Ok(aplikantVjestineResource);
        }
    }
}
