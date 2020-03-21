using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace StatsApi.Models 
{
    [BsonIgnoreExtraElements]
    public class Stats
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("userId")]
        public string UserId { get; set; }

        [BsonElement("strength")]
        [Range(0, 100, ErrorMessage = "Strength stat value must be between 0 and 100")]
        public int Strength { get; set; }

        [BsonElement("intelligence")]
        [Range(0, 100, ErrorMessage = "Intelligence stat value must be between 0 and 100")]
        public int Intelligence { get; set; }

        [BsonElement("fluency")]
        [Range(0, 100, ErrorMessage = "Fluency stat value must be between 0 and 100")]
        public int Fluency { get; set; }

        [BsonElement("creativity")]
        [Range(0, 100, ErrorMessage = "Creativity stat value must be between 0 and 100")]
        public int Creativity { get; set; }

    }

}