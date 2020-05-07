using StatsApi.Models;

namespace ProjectsApi.Dto.Rank
{
    public class GetRank
    {
        public string Name { get; set; }

        public GAMITUDE_STYLE Style { get; set; }

        public RANK_TIER Tier { get; set; }//TODO Migrate to enum

        public RANK_DOMINANT Dominant { get; set; }//TODO Migrate to enum
                 
        public string ImageUrl { get; set; }
    }
}
