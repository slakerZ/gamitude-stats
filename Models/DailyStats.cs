using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace StatsApi.Models
{
    [BsonIgnoreExtraElements]
    public class DailyStats
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("userId")]
        public string UserId { get; set; }

        [BsonElement("strength")]
        [Range(0, 1440, ErrorMessage = "Strength stat time value must be between 0 and 1440")]
        public int Strength { get; set; }

        [BsonElement("intelligence")]
        [Range(0, 1440, ErrorMessage = "Intelligence stat time value must be between 0 and 1440")]
        public int Intelligence { get; set; }

        [BsonElement("fluency")]
        [Range(0, 1440, ErrorMessage = "Fluency stat time value must be between 0 and 1440")]
        public int Fluency { get; set; }

        [BsonElement("creativity")]
        [Range(0, 1440, ErrorMessage = "Creativity stat time value must be between 0 and 1440")]
        public int Creativity { get; set; }

        [BsonElement("date")]
        public DateTime Date { get; set; }

    }
    
}