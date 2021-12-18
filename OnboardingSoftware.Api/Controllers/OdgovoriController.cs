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

        [HttpGet("{pitanjeId}", Name = "GetOdgovoriByPitanjeId")]
        public async Task<ActionResult<IEnumerable<OdgovorResource>>> GetOdgovoriByPitanjeId(int pitanjeId)
        {
            var odgovori = await _odgovorService.GetOdgovoriByPitanjeId(pitanjeId);
            if (odgovori == null)
                return NotFound();
            var odgovorResource = _mapper.Map<IEnumerable<Odgovor>, IEnumerable<OdgovorResource>>(odgovori);

            return Ok(odgovorResource);
        }
    }
}
