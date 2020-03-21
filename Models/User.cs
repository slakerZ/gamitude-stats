using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace StatsApi.Models 
{
    [BsonIgnoreExtraElements]
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("rankSet")]
        public string RankSet { get; set; }

        [BsonElement("tier")]
        public string Tier { get; set; }

        [BsonElement("dateAdded")]
        public DateTime DateAdded { get; set; }
    }
}