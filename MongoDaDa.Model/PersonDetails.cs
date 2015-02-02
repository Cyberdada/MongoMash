using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;





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
