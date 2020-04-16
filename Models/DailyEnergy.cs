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
        public int Mind { get; set; }

        [BsonElement("soul")]
        public int Soul { get; set; }

        [BsonElement("body")]
        public int Body { get; set; }

        [BsonElement("emotional")]
        public int Emotional { get; set; }

        [BsonElement("date")]
        public DateTime Date { get; set; }

        public DailyEnergy validate()
        {
            if (this.Body > 1440) this.Body = 1440;
            else if (this.Body < 0) this.Body = 0;
            if (this.Soul > 1440) this.Soul = 1440;
            else if (this.Soul < 0) this.Soul = 0;
            if (this.Emotional > 1440) this.Emotional = 1440;
            else if (this.Emotional < 0) this.Emotional = 0;
            if (this.Mind > 1440) this.Mind = 1440;
            else if (this.Mind < 0) this.Mind = 0;
            return this;
        }
    }


}