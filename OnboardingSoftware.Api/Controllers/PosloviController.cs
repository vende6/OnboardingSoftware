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
    public class PosloviController : ControllerBase
    {
        private readonly IPosaoService _posaoService;
        private readonly IMapper _mapper;
        public PosloviController(IPosaoService posaoService, IMapper mapper)
        {
            this._posaoService = posaoService;
            this._mapper = mapper;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<PosaoResource>>> GetAllPoslovi()
        {
            var poslovi = await this._posaoService.GetAllWithLokacija();
            var posaoResources = _mapper.Map<IEnumerable<Posao>, IEnumerable<PosaoResource>>(poslovi);

            return Ok(posaoResources);
        }
    }
}
