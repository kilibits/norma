using System.Collections.Generic;
using System.Threading.Tasks;
using myrep.Models;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using System;

namespace myrep.Services
{
    public class DataService: IDataService
    {
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<Profile> _profilesCollection;


        public DataService(IConfiguration config)
        {
            var dbConfig = config.GetSection("DatabaseConnection");
            var client = new MongoClient(dbConfig.GetValue<string>("ConnectionString"));           
            _database = client.GetDatabase(dbConfig.GetValue<string>("Database"));
            _profilesCollection = _database.GetCollection<Profile>(dbConfig.GetValue<string>("Collection"));
            client.StartSession();
        }

        public async Task<IEnumerable<BaseProfile>> GetBaseProfilesAsync()
        {
            return await _profilesCollection.Find(profile => true).ToListAsync();          
        }

        public async Task<IEnumerable<Profile>> GetFullProfilesAsync()
        {
            return await _profilesCollection.Find(profile => true).ToListAsync();
        }
  
        public async Task<Profile> GetProfileAsync(int profileId)
        {
            var res = await _profilesCollection.Find(profile => profile.ProfileId == profileId).FirstOrDefaultAsync();
            return res;
        }
        
        public async Task<IEnumerable<BaseProfile>> GetBaseProfilesByPartyAsync(string party)
        {
            return await _profilesCollection.Find(profile => profile.PoliticalParty == party).ToListAsync();
        }
        
        public async Task<IEnumerable<BaseProfile>> GetBaseProfilesByTypeAsync(string memberType)
        {
            return await _profilesCollection.Find(profile => profile.MemberType == memberType).ToListAsync();
        }

        public async Task<IEnumerable<BaseProfile>> SearchAllAsync(string searchString){
            return await _profilesCollection.Find(profile => profile.Address.Contains(searchString) || profile.FullName.Contains(searchString)
                                                  || profile.Constituency.Contains(searchString) || profile.PoliticalParty.Contains(searchString)).ToListAsync();
        }
    }
}