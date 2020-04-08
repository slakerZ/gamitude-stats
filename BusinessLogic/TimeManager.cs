using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ProjectsApi.Dto.TimeSpend;
using StatsApi.Dto;
using StatsApi.Models;
using StatsApi.Services;

namespace StatsApi.BusinessLogic
{
    public interface ITimeManager
    {
        Task<ControllerResponse<CreateTimeSpend>> manageTime(CreateTimeSpend createTimeSpend);
    }

    public class TimeManager : ITimeManager
    {
        public TimeManager(ILogger<TimeManager> logger,IHttpClientFactory clientFactory
                            ,IDailyStatsService dailyStatsService,IDailyEnergyService dailyEnergyService)
        {

        }
        public async Task<ControllerResponse<CreateTimeSpend>> manageTime(CreateTimeSpend createTimeSpend)
        {
            
            /*TODO
            //- await get dEnergy
            //- await calculateEnergy
            //- await save dEnergy
            //- await http request to User
            //
            //- await get dStats
            //- await calculateStats
            //- await save dStats
            //- await http request to User
            */
            return null;
        }
        private DailyEnergy calculateEnergy(DailyEnergy energy, TimeSpend timeSpend)
        {
            throw new System.NotImplementedException();
        }

        private DailyStats calculateStats(DailyStats energy, TimeSpend timeSpend)
        {
            throw new System.NotImplementedException();
        }
    }
}