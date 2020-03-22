using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace StatsApi.Models 
{

    [BsonIgnoreExtraElements]
    public class ProjectUsage
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("projectId")]
        public string ProjectId { get; set; }

        [BsonElement("dominantStat")]
        public STATS DominantStat { get; set; }

        [BsonElement("stats")]
        public STATS[] Stats { get; set; }

        [BsonElement("timeSpend")]
        public int TimeSpend { get; set; }
        
    }

}