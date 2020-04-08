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
        [Range(0, 100, ErrorMessage = "Mind energy value must be between 0 and 100")]
        public int Mind { get; set; }

        [BsonElement("soul")]
        [Range(0, 100, ErrorMessage = "Soul energy value must be between 0 and 100")]
        public int Soul { get; set; }

        [BsonElement("body")]
        [Range(0, 100, ErrorMessage = "Body energy value must be between 0 and 100")]
        public int Body { get; set; }

        [BsonElement("emotional")]
        [Range(0, 100, ErrorMessage = "Emotional energy value must be between 0 and 100")]
        public int Emotional { get; set; }

        [BsonElement("date")]
        public DateTime Date { get; set; } // DateTime.Date

    }
}