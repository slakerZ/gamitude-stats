using AutoMapper;
using ProjectsApi.Dto.Stast;
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
            //DailyStats      
            CreateMap<DailyStats, SendDailyStats>();            
        }        
    }
}   