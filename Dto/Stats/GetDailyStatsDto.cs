using Microsoft.Extensions.Options;
using StatsApi.Helpers;

namespace ProjectsApi.Dto.Stats
{
    public class GetDailyStatsDto
    {

        public int Strength { get; set; }

        public int Intelligence { get; set; }

        public int Fluency { get; set; }

        public int Creativity { get; set; }

        public GetDailyStatsDto scaleToPercent()
        {
            this.Creativity =(this.Creativity*100)/ StaticValues.dayLenght;
            this.Fluency = (this.Fluency*100)/StaticValues.dayLenght;
            this.Intelligence =(this.Intelligence*100)/ StaticValues.dayLenght;
            this.Strength = (this.Strength *100)/StaticValues.dayLenght;
            return this;
        }
    }
}
