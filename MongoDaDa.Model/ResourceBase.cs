using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDaDa.Model
{
    public class ResourceBase
    {
        [BsonId]
        public string Id { get; set; }
        public string Name { get; set; }


    }
}
