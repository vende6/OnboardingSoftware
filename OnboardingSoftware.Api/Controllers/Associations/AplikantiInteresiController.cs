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
    public class AplikantiInteresiController : ControllerBase
    {
        private readonly IAplikantService _aplikantService;
        private readonly IInteresService _interesService;
        private readonly IAplikantInteresService _aplikantInteresService;
        private readonly IMapper _mapper;
        public AplikantiInteresiController(IAplikantInteresService aplikantInteresService, IAplikantService aplikantService, IInteresService interesService, IMapper mapper)
        {
            this._aplikantService = aplikantService;
            this._interesService = interesService;
            this._aplikantInteresService = aplikantInteresService;
            this._mapper = mapper;
        }

        // POST: api/aplikantiInteresi
        [HttpPost("")]
        public async Task<ActionResult<bool>> CreateAplikantInteresi([FromBody] SaveAplikantInteresiResource saveAplikantInteresiResource)
        {
            try
            {
                var aplikant = await _aplikantService.GetAplikantByEmail(saveAplikantInteresiResource.Email);
                if (aplikant == null)
                    return NotFound(false);

                saveAplikantInteresiResource.AplikantID = aplikant.ID;

                var aplikantInteresToCreate = _mapper.Map<IEnumerable<SaveInteresResource>, IEnumerable<AplikantInteres>>(saveAplikantInteresiResource.Interesi);

                await _aplikantInteresService.CreateAplikantInteresi(aplikantInteresToCreate);

                return Ok(true);
            }
            catch (Exception ex)
            {
                var eex = ex;
                throw;
            }
        }

        [HttpGet("")]
        public async Task<ActionResult<AplikantInteresiResource>> GetAllAplikantInteresi(string email)
        {
            var aplikant = await _aplikantService.GetAplikantByEmail(email);
            if (aplikant == null)
                return NotFound(false);

            var interesi = await _interesService.GetInterests();
            var interesiResource = _mapper.Map<IEnumerable<Interes>, IEnumerable<InteresResource>>(interesi);

            var aplikantInteresi = await _aplikantInteresService.GetApplicantInterests(aplikant.ID);
            foreach (var item in aplikantInteresi)
            {
                if (item.AplikantID == aplikant.ID)
                {
                    interesiResource.FirstOrDefault(c => c.ID == item.InteresID).IsSelected = true;

                }
            }

            var aplikantInteresiResource = _mapper.Map<IEnumerable<InteresResource>, AplikantInteresiResource>(interesiResource);

            return Ok(aplikantInteresiResource);
        }

    }
}
