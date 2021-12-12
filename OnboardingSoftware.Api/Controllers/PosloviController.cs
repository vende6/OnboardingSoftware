using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnboardingSoftware.Api.Resources;
using OnboardingSoftware.Core.Models;
using OnboardingSoftware.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
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

        // POST: api/poslovi
        [HttpPost("")]
        public async Task<ActionResult<bool>> CreatePosao([FromBody] SavePosaoResource savePosaoResource)
        {

            //var validator = new SaveLinkResourceValidator();
            //var validationResult = await validator.ValidateAsync(saveLinkResource);
            //if (!validationResult.IsValid)
            //    return BadRequest(validationResult.Errors);

            var posaoToCreate = _mapper.Map<SavePosaoResource, Posao>(savePosaoResource);
            await _posaoService.CreatePosao(posaoToCreate);
       

            //await _userLinkService.CreateUserLink(new UserLink { LinkId = link.ID, TagId = tag.ID, UserId = Guid.Parse(userId) });

            return Ok(true);
        }

    }
}
