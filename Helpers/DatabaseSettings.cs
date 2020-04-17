using System;

namespace StatsApi.Helpers
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public String DailyStatsCollectionName { get; set; }
        public String DailyEnergyCollectionName { get; set; }
        public String TimeSpendCollectionName { get; set; }
        public String ConnectionString { get; set; }
        public String DatabaseName { get; set; }
    }

    public interface IDatabaseSettings
    {
        String DailyStatsCollectionName { get; set; }
        String DailyEnergyCollectionName { get; set; }
        String TimeSpendCollectionName { get; set; }
        String ConnectionString { get; set; }
        String DatabaseName { get; set; }
    }
}