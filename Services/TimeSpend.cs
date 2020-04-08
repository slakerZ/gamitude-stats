using StatsApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System;

namespace StatsApi.Services
{
    public class TimeSpendService
    {
        private readonly IMongoCollection<TimeSpend> _TimeSpend;


        public TimeSpendService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _TimeSpend = database.GetCollection<TimeSpend>(settings.TimeSpendCollectionName);
        }

        public TimeSpend GetTimeSpendByProjectId(string projectId) =>
            _TimeSpend.Find<TimeSpend>(TimeSpend => TimeSpend.ProjectId == projectId).FirstOrDefault();

        public TimeSpend Get(string id) =>
            _TimeSpend.Find<TimeSpend>(TimeSpend => TimeSpend.Id == id).FirstOrDefault();

        public TimeSpend Create(TimeSpend TimeSpend)
        {
            _TimeSpend.InsertOne(TimeSpend);
            return TimeSpend;
        }

        public void Update(string id, TimeSpend ProjectIn) =>
            _TimeSpend.ReplaceOne(TimeSpend => TimeSpend.Id == id, ProjectIn);

        public void Remove(TimeSpend ProjectIn) =>
            _TimeSpend.DeleteOne(TimeSpend => TimeSpend.Id == ProjectIn.Id);

        public void Remove(string id) => 
            _TimeSpend.DeleteOne(TimeSpend => TimeSpend.Id == id);
    }
}