using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace StatsApi.Models 
{
    [BsonIgnoreExtraElements]
    public class TimeSpend
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("projectId")]
        public string ProjectId { get; set; }

        [BsonElement("breakId")]
        public string BreakId { get; set; }

        [BsonElement("timeSpend")]
        public int TimeSpend { get; set; }
        
        [BsonElement("dominantStat")]
        public STATS DominantStat { get; set; }

        [BsonElement("stats")]
        public STATS[] Stats { get; set; }

        public int[] getWages()
        {
            //TODO calculate wages [Body,Mind,Soul,Emotional]
            return [3,1,1,0];
        }

    }

    
}