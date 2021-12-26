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
    public class VjestineController : ControllerBase
    {
        private readonly IVjestinaService _vjestinaService;
        private readonly IMapper _mapper;
        public VjestineController(IVjestinaService vjestinaService, IMapper mapper)
        {
            this._vjestinaService = vjestinaService;
            this._mapper = mapper;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<SkillResource>>> GetAllVjestine()
        {
            var vjestine = await this._vjestinaService.GetSkillsAsync();
            var vjestineResources = _mapper.Map<IEnumerable<Vjestina>, IEnumerable<SkillResource>>(vjestine);

            return Ok(vjestineResources);
        }

        // POST: api/vjestine
        [HttpPost("")]
        public async Task<ActionResult<bool>> CreateVjestina([FromBody] SaveVjestinaResource saveVjestinaResource)
        {

            var vjestinaToCreate = _mapper.Map<SaveVjestinaResource, Vjestina>(saveVjestinaResource);
            await _vjestinaService.CreateVjestina(vjestinaToCreate);

            return Ok(true);
        }

    }
}
