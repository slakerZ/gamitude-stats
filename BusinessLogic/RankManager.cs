using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using ProjectsApi.Dto.Rank;
using ProjectsApi.Dto.Stats;
using StatsApi.Dto;
using StatsApi.Models;
using StatsApi.Services;

namespace StatsApi.BusinessLogic
{//TODO talk about rank zones ???
    public interface IRankManager
    {
        Task manageRank(String userId);
    }

    public class RankManager : IRankManager
    {
        /// <summary>
        /// This class is responisible for rank selection after user session 
        /// </summary>

        private readonly ILogger<RankManager> _logger;
        private readonly IMapper _mapper;
        private readonly IRankService _ranksService;
        private readonly IUserRankService _userRankService;
        private readonly IDailyStatsService _dailyStatsService;
        private String userId;
        private GetLastWeekAvgStatsDto stats;
        private UserRank userRank;

        public RankManager(ILogger<RankManager> logger, IMapper mapper, IRankService ranksService, IUserRankService userRankService
                            , IDailyStatsService dailyStatsService)
        {
            _logger = logger;
            _mapper = mapper;
            _ranksService = ranksService;
            _userRankService = userRankService;
            _dailyStatsService = dailyStatsService;
        }
        public async Task manageRank(String userId)
        {
            try
            {
                this.userId = userId;
                stats = await _dailyStatsService.GetLastWeekAvgStatsByUserIdAsync(userId);
                await calculateRank();
                await _userRankService.UpdateAsync(userRank);
            }
            catch (Exception e)
            {
                _logger.LogError("Error cached in RankManager manageRank {error}", e);
                throw e;
            }
        }
        private async Task calculateRank()
        {
            RANK_TIER tier = RANK_TIER.A;
            RANK_DOMINANT dominant = RANK_DOMINANT.BALANCED;
            GAMITUDE_STYLE style = GAMITUDE_STYLE.DEFAULT;

            var sum = stats.Strength + stats.Intelligence + stats.Fluency + stats.Creativity;
            var max = new List<int> { stats.Strength, stats.Intelligence, stats.Fluency, stats.Creativity }.Max();

            if (max == stats.Strength)
            {
                dominant = RANK_DOMINANT.STRENGHT;
            }
            else if (max == stats.Intelligence)
            {
                dominant = RANK_DOMINANT.INTELLIGENCE;
            }
            else if (max == stats.Fluency)
            {
                dominant = RANK_DOMINANT.FLUENCY;
            }
            else if (max == stats.Creativity)
            {
                dominant = RANK_DOMINANT.CREATIVITY;
            }
            else
            {
                dominant = RANK_DOMINANT.BALANCED;
            }

            if (sum < 40)
            {
                tier = RANK_TIER.A;
            }
            else if (sum >= 40 && sum < 90)
            {
                tier = RANK_TIER.B;
            }
            else if (sum >= 90 && sum < 150)
            {
                tier = RANK_TIER.C;
            }
            else if (sum >= 150 && sum < 230)
            {
                tier = RANK_TIER.D;
            }
            else if (sum >= 230 && sum < 320)
            {
                tier = RANK_TIER.F;
            }
            else if (sum >= 320)
            {
                tier = RANK_TIER.S;
            }

            userRank =  new UserRank
            {
                UserId = userId,
                RankId = await _ranksService.GetIdByTierDominantAsync(tier, dominant, style)
            };

        }

    }
}