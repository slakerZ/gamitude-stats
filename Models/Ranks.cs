using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace StatsApi.Models 
{

    [BsonIgnoreExtraElements]
    public class Ranks
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("rankSet")]
        public RANK_SET RankSet { get; set; }

        [BsonElement("tier")]
        public string Tier { get; set; }//TODO Migrate to enum
                
        [BsonElement("image")]
        public string ImageUrl { get; set; }



    }

}