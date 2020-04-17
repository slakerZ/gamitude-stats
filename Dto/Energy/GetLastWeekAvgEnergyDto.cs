using Microsoft.Extensions.Options;
using StatsApi.Helpers;

namespace ProjectsApi.Dto.Energy
{
    public class GetLastWeekAvgEnergyDto
    {
        private readonly int dayLenght = 1440;
        public int Emotional { get; set; }

        public int Soul { get; set; }

        public int Body { get; set; }

        public int Mind { get; set; }
        public GetLastWeekAvgEnergyDto weekAvg()
        {
            this.Emotional /= 7;
            this.Soul /= 7;
            this.Body /= 7;
            this.Mind /= 7;
            return this;
        }

        public GetLastWeekAvgEnergyDto scaleToPercent()
        {
            this.Body /= dayLenght / 100;
            this.Soul /= dayLenght / 100;
            this.Emotional /= dayLenght / 100;
            this.Mind /= dayLenght / 100;
            return this;
        }
    }
}
