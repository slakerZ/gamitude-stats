using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using StatsApi.Helpers;

namespace StatsApi.Models
{
    [BsonIgnoreExtraElements]
    public class DailyStats
    {
        private readonly int dayLenght = 1440;
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
            if (this.Creativity > dayLenght) this.Creativity = dayLenght;
            else if (this.Creativity < 0) this.Creativity = 0;
            if (this.Fluency > dayLenght) this.Fluency = dayLenght;
            else if (this.Fluency < 0) this.Fluency = 0;
            if (this.Intelligence > dayLenght) this.Intelligence = dayLenght;
            else if (this.Intelligence < 0) this.Intelligence = 0;
            if (this.Strength > dayLenght) this.Strength = dayLenght;
            else if (this.Strength < 0) this.Strength = 0;
            return this;
        }

    }

}