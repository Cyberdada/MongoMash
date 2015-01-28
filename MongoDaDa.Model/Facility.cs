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
    public class Facility
    {
      
        public ObjectId Id { get; set; }

        [BsonRequired]
        public string Name { get; set; }

        [BsonIgnoreIfNull]
        public string Manufacturer { get; set; }

        public List<string> GroupsThatCanBook { get; set; } 

    
  
    
    }

}
