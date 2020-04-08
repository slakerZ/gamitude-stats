using StatsApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace StatsApi.Services
{

    public interface IDailyEnergyService
    {
        DailyEnergy GetDailyEnergyByUserId(String userId);
        DailyEnergy Get(String id);
        DailyEnergy Create(DailyEnergy dailyEnergy);
        void Update(String id, DailyEnergy ProjectIn);
        void Remove(DailyEnergy ProjectIn);
        void Remove(string id);


    }


    public class DailyEnergyService
    {
        private readonly IMongoCollection<DailyEnergy> _DailyEnergy;


        public DailyEnergyService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _DailyEnergy = database.GetCollection<DailyEnergy>(settings.DailyEnergyCollectionName);
        }

        public DailyEnergy GetDailyEnergyByUserId(string userId) =>
            _DailyEnergy.Find<DailyEnergy>(DailyEnergy => DailyEnergy.UserId == userId).FirstOrDefault();

        public DailyEnergy Get(string id) =>
            _DailyEnergy.Find<DailyEnergy>(DailyEnergy => DailyEnergy.Id == id).FirstOrDefault();

        public DailyEnergy Create(DailyEnergy DailyEnergy)
        {
            _DailyEnergy.InsertOne(DailyEnergy);
            return DailyEnergy;
        }

        public void Update(string id, DailyEnergy ProjectIn) =>
            _DailyEnergy.ReplaceOne(DailyEnergy => DailyEnergy.Id == id, ProjectIn);

        public void Remove(DailyEnergy ProjectIn) =>
            _DailyEnergy.DeleteOne(DailyEnergy => DailyEnergy.Id == ProjectIn.Id);

        public void Remove(string id) =>
            _DailyEnergy.DeleteOne(DailyEnergy => DailyEnergy.Id == id);
    }
}