using AutoMapper;
using ProjectsApi.Dto.Energy;
using ProjectsApi.Dto.Rank;
using ProjectsApi.Dto.Stats;
using ProjectsApi.Dto.TimeSpend;
using StatsApi.Models;

namespace error_interface
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //TimeSpend
            CreateMap<CreateTimeSpend, TimeSpend>();
            CreateMap<TimeSpend, GetTimeSpend>();

            //Rank
            CreateMap<Rank, GetRank>();

            //DailyStats
            CreateMap<DailyStats,GetDailyStatsDto>();
            
            //DailyEnergy
            CreateMap<DailyEnergy,GetDailyEnergyDto>();
        }
    }
}