using System;
using System.Collections.Generic;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace MongoDaDa.Model
{
    class Booking
    {

        public ObjectId Id { get; set; }
        
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime StartTime { get;set; }
        
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime EndTime { get; set; }


        public string PersonId { get; set; }
        public string PersonName { get; set; }

        public string ResourceId { get; set; }
        public string ResourceName { get; set; }

        [BsonIgnoreIfNull]
        public List<PersonBase> Attending { get; set; }

       

    }
}
