using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
    public class AplikantiController : ControllerBase
    {
        private readonly IAplikantService _aplikantService;
        public AplikantiController(IAplikantService aplikantService, IMapper mapper)
        {
            this._aplikantService = aplikantService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Aplikant>>> GetAllAplikanti()
        {
            var aplikanti = await this._aplikantService.GetAllWithVjestine();
            return Ok(aplikanti);
        }
    }
}
