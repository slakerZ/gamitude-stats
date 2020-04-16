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
        public int Strength { get; set; }

        [BsonElement("intelligence")]
        public int Intelligence { get; set; }

        [BsonElement("fluency")]
        public int Fluency { get; set; }

        [BsonElement("creativity")]
        public int Creativity { get; set; }

        [BsonElement("date")]
        public DateTime Date { get; set; }

        public DailyStats validate()
        {
            if (this.Creativity > 1440) this.Creativity = 1440;
            else if (this.Creativity < 0) this.Creativity = 0;
            if (this.Fluency > 1440) this.Fluency = 1440;
            else if (this.Fluency < 0) this.Fluency = 0;
            if (this.Intelligence > 1440) this.Intelligence = 1440;
            else if (this.Intelligence < 0) this.Intelligence = 0;
            if (this.Strength > 1440) this.Strength = 1440;
            else if (this.Strength < 0) this.Strength = 0;
            return this;
        }
    }
    
}