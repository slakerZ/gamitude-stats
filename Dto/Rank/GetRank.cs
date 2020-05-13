using StatsApi.Models;

namespace ProjectsApi.Dto.Rank
{
    public class GetRank
    {
        public string Name { get; set; }

        public GAMITUDE_STYLE Style { get; set; }

        public RANK_TIER Tier { get; set; }

        public RANK_DOMINANT Dominant { get; set; }
                 
        public string ImageUrl { get; set; }
    }
}
