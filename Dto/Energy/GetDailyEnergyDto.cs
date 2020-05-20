using System;
using Microsoft.Extensions.Options;
using StatsApi.Helpers;

namespace ProjectsApi.Dto.Energy
{
    public class GetDailyEnergyDto
    {
        public int Emotions { get; set; }

        public int Soul { get; set; }

        public int Body { get; set; }

        public int Mind { get; set; }
        public int dayCount;
        public GetDailyEnergyDto scaleToPercent()
        {
            this.Body = (this.Body * 100) / StaticValues.dayLenght;
            this.Soul = (this.Soul * 100) / StaticValues.dayLenght;
            this.Emotions = (this.Emotions * 100) / StaticValues.dayLenght;
            this.Mind = (this.Mind * 100) / StaticValues.dayLenght;
            return this;
        }
    }
}
