using StatsApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace StatsApi.Services
{

    public interface IDailyStatsService
    {
        DailyStats GetDailyStatsByUserId(String userId);
        DailyStats Get(String id);
        DailyStats Create(DailyStats dailyStats);
        void Update(String id, DailyStats ProjectIn);
        void Remove(DailyStats ProjectIn);
        void Remove(string id);


    }


    public class DailyStatsService
    {
        private readonly IMongoCollection<DailyStats> _DailyStats;


        public DailyStatsService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _DailyStats = database.GetCollection<DailyStats>(settings.DailyStatsCollectionName);
        }

        public DailyStats GetDailyStatsByUserId(string userId) =>
            _DailyStats.Find<DailyStats>(DailyStats => DailyStats.UserId == userId).FirstOrDefault();

        public DailyStats Get(string id) =>
            _DailyStats.Find<DailyStats>(DailyStats => DailyStats.Id == id).FirstOrDefault();

        public DailyStats Create(DailyStats DailyStats)
        {
            _DailyStats.InsertOne(DailyStats);
            return DailyStats;
        }

        public void Update(string id, DailyStats ProjectIn) =>
            _DailyStats.ReplaceOne(DailyStats => DailyStats.Id == id, ProjectIn);

        public void Remove(DailyStats ProjectIn) =>
            _DailyStats.DeleteOne(DailyStats => DailyStats.Id == ProjectIn.Id);

        public void Remove(string id) =>
            _DailyStats.DeleteOne(DailyStats => DailyStats.Id == id);
    }
}