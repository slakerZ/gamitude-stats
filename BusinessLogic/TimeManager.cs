using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using ProjectsApi.Dto.TimeSpend;
using StatsApi.Dto;
using StatsApi.Models;
using StatsApi.Services;

namespace StatsApi.BusinessLogic
{//TODO talk about time zones ???
    public interface ITimeManager
    {
        Task<GetTimeSpend> manageTime(TimeSpend timeSpend);
    }

    public class TimeManager : ITimeManager
    {
        private readonly ILogger<TimeManager> _logger;
        private readonly IMapper _mapper;
        private readonly ITimeSpendService _timeSpendsService;
        private readonly IDailyStatsService _dailyStatsService;
        private readonly IDailyEnergyService _dailyEnergyService;

        public TimeManager(ILogger<TimeManager> logger, IMapper mapper, ITimeSpendService timeSpendsService
                            , IDailyStatsService dailyStatsService, IDailyEnergyService dailyEnergyService)
        {
            _logger = logger;
            _mapper = mapper;
            _timeSpendsService = timeSpendsService;
            _dailyStatsService = dailyStatsService;
            _dailyEnergyService = dailyEnergyService;
        }
        public async Task<GetTimeSpend> manageTime(TimeSpend timeSpend)
        {
            try
            {
                Dictionary<STATS, int> wages = timeSpend.getWages();
                List<Task> managersTasks = new List<Task>();
                managersTasks.Add(Task.Run(() => manageEnergyAsync(wages, timeSpend)));
                managersTasks.Add(Task.Run(() => manageStatsAsync(wages, timeSpend)));
                managersTasks.Add(Task.Run(() => _timeSpendsService.CreateAsync(timeSpend)));
                await Task.WhenAll(managersTasks);

                return _mapper.Map<GetTimeSpend>(timeSpend);
            }
            catch (Exception e)
            {
                _logger.LogError("Error cached in TimeManager manageTime {error}", e);
                throw e;
            }
        }
        private async Task manageEnergyAsync(Dictionary<STATS, int> wages, TimeSpend timeSpend)
        {
            DailyEnergy dailyEnergy = calculateEnergy(wages, timeSpend);
            dailyEnergy.UserId = timeSpend.UserId;
            dailyEnergy.Date = DateTime.UtcNow.Date;
            _logger.LogInformation(dailyEnergy.ToString());
            await _dailyEnergyService.CreateOrAddAsync(dailyEnergy);
        }
        private async Task manageStatsAsync(Dictionary<STATS, int> wages, TimeSpend timeSpend)
        {
            DailyStats dailyStats = calculateStats(wages, timeSpend);
            dailyStats.UserId = timeSpend.UserId;
            dailyStats.Date = DateTime.UtcNow.Date;
            await _dailyStatsService.CreateOrAddAsync(dailyStats);
        }
        private DailyEnergy calculateEnergy(Dictionary<STATS, int> wages, TimeSpend timeSpend)
        {
            switch (timeSpend.ProjectType)
            {
                case (PROJECT_TYPE.ENERGY):
                    return calculateEnergyProjectEnergy(wages, timeSpend.Duration);
                case (PROJECT_TYPE.STATS):
                    return calculateStatsProjectEnergy(wages, timeSpend.Duration);

                default:
                    return null;
            }

        }

        private DailyEnergy calculateEnergyProjectEnergy(Dictionary<STATS, int> wages, int duration)
        {
            duration >>=2;
            return new DailyEnergy
            {
                Body = duration * wages.GetValueOrDefault(STATS.STRENGTH),
                Soul = duration * wages.GetValueOrDefault(STATS.FLUENCY),
                Emotional = duration * wages.GetValueOrDefault(STATS.CREATIVITY),
                Mind = duration * wages.GetValueOrDefault(STATS.INTELLIGENCE)
            };

            throw new System.NotImplementedException();
        }

        private DailyEnergy calculateStatsProjectEnergy(Dictionary<STATS, int> wages, int duration)
        {
            duration *= -1;
            return new DailyEnergy
            {
                Body = duration * wages.GetValueOrDefault(STATS.STRENGTH),
                Soul = duration * wages.GetValueOrDefault(STATS.FLUENCY),
                Emotional = duration * wages.GetValueOrDefault(STATS.CREATIVITY),
                Mind = duration * wages.GetValueOrDefault(STATS.INTELLIGENCE)
            };

            throw new System.NotImplementedException();
        }

        private DailyStats calculateStats(Dictionary<STATS, int> wages, TimeSpend timeSpend)
        {
            switch (timeSpend.ProjectType)
            {
                case (PROJECT_TYPE.ENERGY):
                    return calculateEnergyProjectStats(wages, timeSpend.Duration);
                case (PROJECT_TYPE.STATS):
                    return calculateStatsProjectStats(wages, timeSpend.Duration);

                default:
                    return null;
            }
        }

        private DailyStats calculateEnergyProjectStats(Dictionary<STATS, int> wages, int duration)
        {
            duration >>=2;
            return new DailyStats
            {
                Strength = duration * wages.GetValueOrDefault(STATS.STRENGTH),
                Creativity = duration * wages.GetValueOrDefault(STATS.CREATIVITY),
                Fluency = duration * wages.GetValueOrDefault(STATS.FLUENCY),
                Intelligence = duration * wages.GetValueOrDefault(STATS.INTELLIGENCE)
            };
        }

        private DailyStats calculateStatsProjectStats(Dictionary<STATS, int> wages, int duration)
        {

            return new DailyStats
            {
                Strength = duration * wages.GetValueOrDefault(STATS.STRENGTH),
                Creativity = duration * wages.GetValueOrDefault(STATS.CREATIVITY),
                Fluency = duration * wages.GetValueOrDefault(STATS.FLUENCY),
                Intelligence = duration * wages.GetValueOrDefault(STATS.INTELLIGENCE)
            };
        }

    }
}