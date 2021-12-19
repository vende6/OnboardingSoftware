
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnboardingSoftware.Api.Resources;
using OnboardingSoftware.Core.Models;
using OnboardingSoftware.Core.Services;
using OnboardingSoftware.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnboardingSoftware.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestoviController : ControllerBase
    {
        private readonly ITestService _testService;
        private readonly IMapper _mapper;
        public TestoviController(ITestService testService, IMapper mapper)
        {
            this._testService = testService;
            this._mapper = mapper;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<TestResource>>> GetAllTestovi()
        {
            var testovi = await this._testService.GetTestovi();
            var testResources = _mapper.Map<IEnumerable<Test>, IEnumerable<TestResource>>(testovi);

            return Ok(testResources);
        }

        [HttpGet("{id}", Name = "GetTestById")]
        public async Task<ActionResult<TestResource>> GetTestById(int id)
        {
            var test = await _testService.GetTestById(id);
            if (test == null)
                return NotFound();
            var testResource = _mapper.Map<Test, TestResource>(test);

            return Ok(testResource);
        }

        // POST: api/testovi
        [HttpPost("")]
        public async Task<ActionResult<bool>> CreateTest([FromBody] SaveTestResource testResource)
        {

            //var validator = new SaveLinkResourceValidator();
            //var validationResult = await validator.ValidateAsync(saveLinkResource);
            //if (!validationResult.IsValid)
            //    return BadRequest(validationResult.Errors);

            var test = _mapper.Map<SaveTestResource, Test>(testResource);
            await _testService.CreateTest(test);


            //await _userLinkService.CreateUserLink(new UserLink { LinkId = link.ID, TagId = tag.ID, UserId = Guid.Parse(userId) });

            return Ok(true);
        }
    }
}
