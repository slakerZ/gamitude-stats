using AutoMapper;
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
            CreateMap<TimeSpend,GetTimeSpend>();      
        }        
    }
}   