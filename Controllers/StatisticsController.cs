﻿
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectsApi.Dto.Energy;
using ProjectsApi.Dto.Stats;
using StatsApi.Dto;
using StatsApi.Services;

namespace StatsApi.Controllers
{
    [Route("api/stats/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class StatisticsController : ControllerBase
    {

        private readonly ILogger<StatisticsController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IDailyEnergyService _dailyEnergyService;
        private readonly IDailyStatsService _dailyStatsService;

        public StatisticsController(ILogger<StatisticsController> logger, IHttpContextAccessor httpContextAccessor, IDailyEnergyService dailyEnergyService, IDailyStatsService dailyStatsService)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _dailyEnergyService = dailyEnergyService;
            _dailyStatsService = dailyStatsService;
        }


        [HttpGet]
        public async Task<ActionResult<ControllerResponse<GetLastWeekAvgStatsDto>>> stats()
        {
            try
            {
                _logger.LogInformation("In GET GetStats");
                string userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name).ToString();
                if (null != userId)
                {
                    return new ControllerResponse<GetLastWeekAvgStatsDto>
                    {
                        data = await _dailyStatsService.GetLastWeekAvgStatsByUserIdAsync(userId)
                    };
                }
                else
                {
                    _logger.LogError("In GET GetStats UserId error");

                    return new ControllerResponse<GetLastWeekAvgStatsDto>
                    {
                        data = null,
                        message = "UserId error",
                        success = false
                    };
                }

            }
            catch (System.Exception e)
            {
                _logger.LogError("Error cached in StatisticsController GET GetStats {error}", e);

                return new ControllerResponse<GetLastWeekAvgStatsDto>
                {
                    data = null,
                    message = "something went wrong, sorry:(",
                    success = false
                };
            }
        }

        [HttpGet]
        public async Task<ActionResult<ControllerResponse<GetLastWeekAvgEnergyDto>>> energy()
        {
            try
            {
                _logger.LogInformation("In GET GetEnergy");

                string userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name).ToString();
                if (null != userId)
                {
                    return new ControllerResponse<GetLastWeekAvgEnergyDto>
                    {
                        data = await _dailyEnergyService.GetLastWeekAvgEnergyByUserIdAsync(userId)
                    };
                }
                else
                {
                    _logger.LogError("In GET GetEnergy UserId error");

                    return new ControllerResponse<GetLastWeekAvgEnergyDto>
                    {
                        data = null,
                        message = "UserId error",
                        success = false
                    };
                }

            }
            catch (System.Exception e)
            {
                _logger.LogError("Error cached in StatisticsController GET GetEnergy {error}", e);

                return new ControllerResponse<GetLastWeekAvgEnergyDto>
                {
                    data = null,
                    message = "something went wrong, sorry:(",
                    success = false
                };
            }
        }
    }
}
