namespace ProjectsApi.Dto.Energy
{
    public class GetLastWeekAvgEnergyDto
    {
        public int Emotional { get; set; }

        public int Soul { get; set; }

        public int Body { get; set; }

        public int Mind { get; set; }
        public GetLastWeekAvgEnergyDto weekAvg()
        {
            this.Emotional/=7;
            this.Soul/=7;
            this.Body/=7;
            this.Mind/=7;
            return this;
        }
    }
}
