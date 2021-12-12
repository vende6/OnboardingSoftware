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
    public class PosloviController : ControllerBase
    {
        private readonly IPosaoService _posaoService;
        public PosloviController(IPosaoService posaoService, IMapper mapper)
        {
            this._posaoService = posaoService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Posao>>> GetAllPoslovi()
        {
            var poslovi = await this._posaoService.GetAllWithLokacija();
            return Ok(poslovi);
        }
    }
}
