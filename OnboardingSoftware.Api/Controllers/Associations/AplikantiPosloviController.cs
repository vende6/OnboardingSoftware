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
    public class AplikantiPosloviController : ControllerBase
    {
        private readonly IAplikantPosaoService _aplikantPosaoService;
        private readonly IAplikantService _aplikantService;
        private readonly IMapper _mapper;
        public AplikantiPosloviController(IAplikantPosaoService aplikantPosaoService, IAplikantService aplikantService, IMapper mapper)
        {
            this._aplikantPosaoService = aplikantPosaoService;
            this._aplikantService = aplikantService;
            this._mapper = mapper;
        }

        // POST: api/aplikantiPoslovi
        [HttpPost("")]
        public async Task<ActionResult<bool>> CreateAplikantPosao([FromBody] SaveAplikantPosaoResource saveAplikantPosaoResource)
        {
            var aplikant = await _aplikantService.GetAplikantByEmail(saveAplikantPosaoResource.Email);
            if (aplikant == null)
                return NotFound(false);

            saveAplikantPosaoResource.AplikantID = aplikant.ID;

            var aplikantPosaoToCreate = _mapper.Map<SaveAplikantPosaoResource, AplikantPosao>(saveAplikantPosaoResource);
            await _aplikantPosaoService.CreateAplikantPosao(aplikantPosaoToCreate);

            return Ok(true);
        }

        [HttpGet("")]
        public async Task<ActionResult<AplikantiPosaoResource>> GetAllAplikantiPosao(int posaoId)
        {
            var aplikantiPosao = await _aplikantPosaoService.GetApplicantsPosao(posaoId);
            var aplikantiPosaoResource = _mapper.Map<IEnumerable<AplikantPosao>, AplikantiPosaoResource>(aplikantiPosao);

            return Ok(aplikantiPosaoResource);
        }

    }
}
