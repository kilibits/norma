using System.Threading.Tasks;
using myrep.Services;
using System.Collections.Generic;
using myrep.Models;
using Microsoft.AspNetCore.Mvc;

namespace myrep.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IDataService _dataService;

        public ProfileController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet]
        [Route("allbase")]
        public async Task<IEnumerable<BaseProfile>> BasicProfiles()
        {
            var result = await _dataService.GetBaseProfilesAsync();
            return result;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IEnumerable<BaseProfile>> Profiles()
        {
            var result = await _dataService.GetFullProfilesAsync();
            return result;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(404)]
        public async Task<ActionResult<BaseProfile>> Profile([FromRoute]int id)
        {
            var result = await _dataService.GetProfileAsync(id);
            if (result == null)
            {
                return new NotFoundObjectResult(result);
            }
            return result;
        }

        [HttpGet("party/{party}")]
        public async Task<IEnumerable<BaseProfile>> ProfilesByPoliticalParty(string party)
        {
            var result = await _dataService.GetBaseProfilesByPartyAsync(party);
            return result;
        }

        [HttpGet("member/{memberType}")]
        public async Task<IEnumerable<BaseProfile>> ProfilesByMemberType(string memberType)
        {
            var result = await _dataService.GetBaseProfilesByTypeAsync(memberType);
            return result;
        }
    }
}
