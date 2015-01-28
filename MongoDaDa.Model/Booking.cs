using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Options;
using MongoDB.Bson.Serialization.Serializers;

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
