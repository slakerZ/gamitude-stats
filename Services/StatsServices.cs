using StatsApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System;

namespace StatsApi.Services
{
    public class StatsService
    {
        private readonly IMongoCollection<Stats> _Stats;


        public StatsService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _Stats = database.GetCollection<Stats>(settings.StatsCollectionName);
        }

        public List<Stats> GetStatsByUserId(string userId) =>
            _Stats.Find<Stats>(Stats => Stats.UserId == userId).ToList();

        public Stats Get(string id) =>
            _Stats.Find<Stats>(Stats => Stats.Id == id).FirstOrDefault();

        public Stats Create(Stats Stats)
        {
            _Stats.InsertOne(Stats);
            return Stats;
        }

        public void Update(string id, Stats ProjectIn) =>
            _Stats.ReplaceOne(Stats => Stats.Id == id, ProjectIn);

        public void Remove(Stats ProjectIn) =>
            _Stats.DeleteOne(Stats => Stats.Id == ProjectIn.Id);

        public void Remove(string id) => 
            _Stats.DeleteOne(Stats => Stats.Id == id);
    }
}