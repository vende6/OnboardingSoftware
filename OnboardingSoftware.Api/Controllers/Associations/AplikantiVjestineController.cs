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
        private readonly IVjestinaService _vjestinaService;
        private readonly IMapper _mapper;
        public AplikantiVjestineController(IAplikantVjestinaService aplikantVjestinaService, IAplikantService aplikantService, IVjestinaService vjestinaService, IMapper mapper)
        {
            this._aplikantService = aplikantService;
            this._vjestinaService = vjestinaService;
            this._aplikantVjestinaService = aplikantVjestinaService;
            this._mapper = mapper;
        }

        // POST: api/aplikantiVjestine
        [HttpPost("")]
        public async Task<ActionResult<bool>> CreateAplikantVjestine([FromBody] SaveAplikantVjestineResource saveAplikantVjestineResource)
        {
            try
            {
                var aplikant = await _aplikantService.GetAplikantByEmail(saveAplikantVjestineResource.Email);
                if (aplikant == null)
                    return NotFound(false);

                saveAplikantVjestineResource.AplikantID = aplikant.ID;
                saveAplikantVjestineResource.Vjestine.ToList().ForEach(cc => cc.AplikantID = aplikant.ID);

                var aplikantVjestineToCreate = _mapper.Map<IEnumerable<AplikantVjestinaResource>, IEnumerable<AplikantVjestina>>(saveAplikantVjestineResource.Vjestine);

                await _aplikantVjestinaService.CreateAplikantVjestine(aplikantVjestineToCreate);

                return Ok(true);
            }
            catch (Exception ex)
            {
                var eex = ex;
                throw;
            }
        }

        [HttpGet("")]
        public async Task<ActionResult<AplikantVjestineResource>> GetAllAplikantVjestine(string email)
        {
            var aplikant = await _aplikantService.GetAplikantByEmail(email);
            if (aplikant == null)
                return NotFound(false);

            var vjestine = await _vjestinaService.GetSkillsAsync();
            var vjestineResource = _mapper.Map<IEnumerable<Vjestina>, IEnumerable<VjestinaResource>>(vjestine);

            var aplikantVjestine = await _aplikantVjestinaService.GetApplicantSkills(aplikant.ID);
            foreach (var item in aplikantVjestine)
            {
                if (item.AplikantID == aplikant.ID)
                {
                    vjestineResource.FirstOrDefault(c => c.ID == item.VjestinaID).IsSelected = true;

                }
            }

            var aplikantVjestineResource = _mapper.Map<IEnumerable<VjestinaResource>, AplikantVjestineResource>(vjestineResource);

            return Ok(aplikantVjestineResource);
        }

    }
}
