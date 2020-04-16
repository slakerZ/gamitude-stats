namespace ProjectsApi.Dto.Stats
{
    public class GetLastWeekAvgStatsDto
    {
        public int Strength { get; set; }

        public int Intelligence { get; set; }

        public int Fluency { get; set; }

        public int Creativity { get; set; }

        public GetLastWeekAvgStatsDto weekAvg()
        {
            this.Strength/=7;
            this.Intelligence/=7;
            this.Fluency/=7;
            this.Creativity/=7;
            return this;
        }
    }
}
