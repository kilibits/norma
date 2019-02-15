using System.Collections.Generic;
using System.Threading.Tasks;
using myrep.Models;

namespace myrep.Services
{
    public interface IDataService
    {
        Task<IEnumerable<BaseProfile>> GetBaseProfilesAsync();
        Task<IEnumerable<Profile>> GetFullProfilesAsync();
        Task<Profile> GetProfileAsync(int profileId);
        Task<IEnumerable<BaseProfile>> GetBaseProfilesByPartyAsync(string party);
        Task<IEnumerable<BaseProfile>> GetBaseProfilesByTypeAsync(string memberType);
        Task<IEnumerable<BaseProfile>> SearchAllAsync(string searchString);
    }
}
