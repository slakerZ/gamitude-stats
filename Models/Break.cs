using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace StatsApi.Models 
{

    [BsonIgnoreExtraElements]
    public class Break
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("projectId")]
        public string ProjectId { get; set; }

        [BsonElement("breakType")]
        public BREAK BreakType { get; set; }

        [BsonElement("timeSpend")]
        public int TimeSpend { get; set; }
        
    }

}