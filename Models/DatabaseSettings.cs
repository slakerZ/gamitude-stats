namespace StatsApi.Models
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string StatsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
    //     public class ProjectsDatabaseSettingsEnv : IProjectsDatabaseSettings
    // {
    //     public string ProjectsCollectionName { get; set; }
    //     public string ConnectionString { get; set; }
    //     public string DatabaseName { get; set; }
    // }

    public interface IDatabaseSettings
    {
        string StatsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}