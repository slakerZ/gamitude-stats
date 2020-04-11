using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace StatsApi.Models 
{
    [BsonIgnoreExtraElements]
    public class DailyEnergy
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("userId")]
        public string UserId { get; set; }

        [BsonElement("mind")]
        [Range(0, 1440, ErrorMessage = "Mind energy time value must be between 0 and 1440")]
        public int Mind { get; set; }

        [BsonElement("soul")]
        [Range(0, 1440, ErrorMessage = "Soul energy time value must be between 0 and 1440")]
        public int Soul { get; set; }

        [BsonElement("body")]
        [Range(0, 1440, ErrorMessage = "Body energy time value must be between 0 and 1440")]
        public int Body { get; set; }

        [BsonElement("emotional")]
        [Range(0, 1440, ErrorMessage = "Emotional energy time value must be between 0 and 1440")]
        public int Emotional { get; set; }

        [BsonElement("date")]
        public DateTime Date { get; set; }

    }

     [BsonIgnoreExtraElements]
    public class LastWeekAvgEnergy
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("userId")]
        public string UserId { get; set; }

        [BsonElement("strength")]
        [Range(0, 100, ErrorMessage = "Strength stat value must be between 0 and 100")]
        public int Mind { get; set; }

        [BsonElement("intelligence")]
        [Range(0, 100, ErrorMessage = "Intelligence stat value must be between 0 and 100")]
        public int Soul { get; set; }

        [BsonElement("fluency")]
        [Range(0, 100, ErrorMessage = "Fluency stat value must be between 0 and 100")]
        public int Body { get; set; }

        [BsonElement("creativity")]
        [Range(0, 100, ErrorMessage = "Creativity stat value must be between 0 and 100")]
        public int Emotional { get; set; }

    }
}