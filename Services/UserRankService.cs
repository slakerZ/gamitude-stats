using StatsApi.Models;
using MongoDB.Driver;
using System.Linq;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ProjectsApi.Dto.Energy;
using MongoDB.Driver.Linq;
using StatsApi.Helpers;
using System.ComponentModel.DataAnnotations;

namespace StatsApi.Services
{

    public interface IUserRankService
    {
        Task<Rank> GetUserRankByUserId(String userId);
        Task UpdateAsync(UserRank userRank);
    }

    public class UserRankService : IUserRankService
    {
        private readonly IMongoCollection<UserRank> _UserRank;
        private readonly ILogger<UserRankService> _logger;

        public IRankService _RankService { get; }

        public UserRankService(IDatabaseSettings settings, ILogger<UserRankService> logger,IRankService rankService)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _UserRank = database.GetCollection<UserRank>(settings.UserRankCollectionName);
            _logger = logger;
            _RankService = rankService;
        }
        public async Task UpdateAsync(UserRank userRank) =>
            await _UserRank.ReplaceOneAsync(o => o.Id == userRank.Id, userRank);

        public async Task<Rank> GetUserRankByUserId(string userId)
        {
            var userRank = _UserRank.Find<UserRank>(o => o.UserId == userId).FirstOrDefault();
            return await _RankService.GetAsync(userRank.RankId); 
        }

    }
}