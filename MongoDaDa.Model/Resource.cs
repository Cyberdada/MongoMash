using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;



namespace MongoDaDa.Model
{
  
    public   class Resource:ResourceBase
    {
 
        public string Type { get; set; }

        [BsonIgnoreIfNull]
        public int MaxSeats { get; set; }

        [BsonIgnoreIfNull]
        public string Description { get; set; }      
  


    }
}
