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

    public class PersonDetails  :PersonBase
    {
       
        public List<Adress> Adress { get; set; }
  
        [BsonIgnoreIfNull]
         [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime DateOfBirth { get; set; }

        public List<string> Groups { get; set; }

        [BsonExtraElements]
        public BsonDocument CatchAll { get; set; }
    }
}
