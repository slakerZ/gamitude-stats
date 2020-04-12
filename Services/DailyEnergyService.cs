using StatsApi.Models;
using MongoDB.Driver;
using System.Linq;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ProjectsApi.Dto.Energy;
using MongoDB.Driver.Linq;
using StatsApi.Helpers;

namespace StatsApi.Services
{

    public interface IDailyEnergyService
    {
        Task<GetLastWeekAvgEnergyDto> GetLastWeekAvgEnergyByUserIdAsync(String userId);
        DailyEnergy GetDailyEnergyByUserId(String userId);
        DailyEnergy Get(String id);
        DailyEnergy Create(DailyEnergy dailyEnergy);
        Task<DailyEnergy> CreateOrAddAsync(DailyEnergy dailyEnergy);
        Task UpdateAsync(DailyEnergy dailyEnergy);
        void Update(DailyEnergy dailyEnergy);
        void Remove(DailyEnergy dailyEnergy);
        void Remove(String id);

    }


    public class DailyEnergyService : IDailyEnergyService
    {
        private readonly IMongoCollection<DailyEnergy> _DailyEnergy;
        private readonly ILogger<DailyEnergyService> _logger;

        public DailyEnergyService(IDatabaseSettings settings, ILogger<DailyEnergyService> logger)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _DailyEnergy = database.GetCollection<DailyEnergy>(settings.DailyEnergyCollectionName);
            _logger = logger;
        }

        public Task<GetLastWeekAvgEnergyDto> GetLastWeekAvgEnergyByUserIdAsync(String userId)
        {
            return _DailyEnergy.AsQueryable()
                 .Where(o => o.UserId == userId && o.Date > DateTime.UtcNow.Date.AddDays(-7))
                 .GroupBy(o => o.UserId)
                 .Select(o => new GetLastWeekAvgEnergyDto
                 {
                     Body = o.Sum(o => o.Body),
                     Mind = o.Sum(o => o.Mind),
                     Emotional = o.Sum(o => o.Emotional),
                     Soul = o.Sum(o => o.Soul)

                 }).FirstOrDefaultAsync();
        }

        public DailyEnergy GetDailyEnergyByUserId(String userId) =>
            _DailyEnergy.Find<DailyEnergy>(o => o.UserId == userId).FirstOrDefault();

        public DailyEnergy Get(String id) =>
            _DailyEnergy.Find<DailyEnergy>(o => o.Id == id).FirstOrDefault();

        private DailyEnergy initDailyEnergy(DailyEnergy dailyEnergy)
        {
            DailyEnergy newDEnergy = new DailyEnergy
            {
                Body = 1440,
                Emotional = 1440,
                Soul = 1440,
                Mind = 1440
            };
            return mergeDailyEnergy(dailyEnergy,newDEnergy);
        }
        private DailyEnergy mergeDailyEnergy(DailyEnergy dailyEnergy, DailyEnergy oldDEnergy)   //TODO in autoMapper
        {
            dailyEnergy.Body += oldDEnergy.Body;
            dailyEnergy.Emotional += oldDEnergy.Emotional;
            dailyEnergy.Mind += oldDEnergy.Mind;
            dailyEnergy.Soul += oldDEnergy.Soul;
            return dailyEnergy;
        }
        public async Task<DailyEnergy> CreateOrAddAsync(DailyEnergy dailyEnergy)
        {
            try
            {
                var oldDEnergy = await _DailyEnergy.Find(o => o.Date == dailyEnergy.Date && o.UserId == dailyEnergy.UserId).SingleOrDefaultAsync();
                if (null == oldDEnergy)
                {//Create
                    await _DailyEnergy.InsertOneAsync(initDailyEnergy(dailyEnergy));
                }
                else
                {//Update   //TODO use mapper for adding
                    dailyEnergy.Id = oldDEnergy.Id;
                    dailyEnergy = mergeDailyEnergy(dailyEnergy,oldDEnergy);
                    await UpdateAsync(dailyEnergy);
                }
                return dailyEnergy;
            }
            catch (Exception e)
            {
                _logger.LogError("Error cached in DailyEnergyServices CreateOrUpdateAsync {error}", e);
                return null;
            }

        }

        public DailyEnergy Create(DailyEnergy DailyEnergy)
        {
            _DailyEnergy.InsertOne(DailyEnergy);
            return DailyEnergy;
        }

        public void Update(DailyEnergy dailyEnergy) =>
            _DailyEnergy.ReplaceOne(o => o.Id == dailyEnergy.Id, dailyEnergy);

        public async Task UpdateAsync(DailyEnergy dailyEnergy) =>
            await _DailyEnergy.ReplaceOneAsync(o => o.Id == dailyEnergy.Id, dailyEnergy);

        public void Remove(DailyEnergy dailyEnergy) =>
            _DailyEnergy.DeleteOne(o => o.Id == dailyEnergy.Id);

        public void Remove(String id) =>
            _DailyEnergy.DeleteOne(o => o.Id == id);


    }
}