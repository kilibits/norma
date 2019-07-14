using System.Threading.Tasks;
using myrep.Services;
using System.Collections.Generic;
using myrep.Models;
using Microsoft.AspNetCore.Mvc;
using System;

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
            try
            {
                var result = await _dataService.GetBaseProfilesAsync();
                return result;
            } 
            catch(Exception ex)
            {
                ErrorHandler(ex);
            } finally
            {

            }

            return new List<BaseProfile>();
        }

        [HttpGet]
        [Route("all")]
        public async Task<IEnumerable<BaseProfile>> Profiles()
        {
            try
            {
                var result = await _dataService.GetFullProfilesAsync();
                if(result == null)
                {
                }
                return result;
            }
            catch(Exception ex)
            {
                ErrorHandler(ex);
            } finally
            {

            }

            return new List<BaseProfile>();
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(404)]
        public async Task<ActionResult<BaseProfile>> Profile([FromRoute]int id)
        {
            
            try
            {
                var result = await _dataService.GetProfileAsync(id);
                if (result == null)
                {
                    return new NotFoundObjectResult(result);
                }
                return result;
            }
            catch(Exception ex)
            {
                ErrorHandler(ex);
            }
            finally
            {

            }

            return new BaseProfile();
        }

        [HttpGet("party/{party}")]
        public async Task<IEnumerable<BaseProfile>> ProfilesByPoliticalParty(string party)
        {
            try
            {
                var result = await _dataService.GetBaseProfilesByPartyAsync(party);
                if(result == null)
                {

                }
                return result;
            }
            catch (Exception ex)
            {
                ErrorHandler(ex);
            }

            return new List<BaseProfile>();

        }

        [HttpGet("member/{memberType}")]
        public async Task<IEnumerable<BaseProfile>> ProfilesByMemberType(string memberType)
        {
            try
            {
                var result = await _dataService.GetBaseProfilesByTypeAsync(memberType);
                return result;
            }
            catch(Exception ex)
            {
                ErrorHandler(ex);
            }

            return new List<BaseProfile>();
        }

        public void ErrorHandler(Exception exception)
        {
            //TODO: perform logging
        }
    }
}
