using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using StatsApi.Helpers;

namespace StatsApi.Models
{
    [BsonIgnoreExtraElements]
    public class DailyEnergy
    {
        private readonly int dayLenght = 1440;
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("userId")]
        public string UserId { get; set; }

        [BsonElement("mind")]
        public int Mind { get; set; }

        [BsonElement("soul")]
        public int Soul { get; set; }

        [BsonElement("body")]
        public int Body { get; set; }

        [BsonElement("emotional")]
        public int Emotional { get; set; }

        [BsonElement("date")]
        public DateTime Date { get; set; }
        public DailyEnergy init()
        {
            this.Body = dayLenght;
            this.Emotional = dayLenght;
            this.Soul = dayLenght;
            this.Mind = dayLenght;
            return this;
        }
        public DailyEnergy validate()
        {
            if (this.Body > dayLenght) this.Body = dayLenght;
            else if (this.Body < 0) this.Body = 0;
            if (this.Soul > dayLenght) this.Soul = dayLenght;
            else if (this.Soul < 0) this.Soul = 0;
            if (this.Emotional > dayLenght) this.Emotional = dayLenght;
            else if (this.Emotional < 0) this.Emotional = 0;
            if (this.Mind > dayLenght) this.Mind = dayLenght;
            else if (this.Mind < 0) this.Mind = 0;
            return this;
        }

    }


}