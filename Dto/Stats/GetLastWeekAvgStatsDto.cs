using Microsoft.Extensions.Options;
using StatsApi.Helpers;

namespace ProjectsApi.Dto.Stats
{
    public class GetLastWeekAvgStatsDto
    {

        private readonly int dayLenght = 1440;
        public int Strength { get; set; }

        public int Intelligence { get; set; }

        public int Fluency { get; set; }

        public int Creativity { get; set; }

        public GetLastWeekAvgStatsDto weekAvg()
        {
            this.Strength /= 7;
            this.Intelligence /= 7;
            this.Fluency /= 7;
            this.Creativity /= 7;
            return this;
        }

        public GetLastWeekAvgStatsDto scaleToPercent()
        {
            this.Creativity /= dayLenght / 100;
            this.Fluency /= dayLenght / 100;
            this.Intelligence /= dayLenght / 100;
            this.Strength /= dayLenght / 100;
            return this;
        }
    }
}
