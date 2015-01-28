using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDaDa.Model
{
    class PointLocation
    {
        [BsonDefaultValue("Point")]
        public string type { get; private set; }

        public int[] coordinates {get;set;}

//              "location" : { "type" : "Point", "coordinates" : [ -73.9667, 40.78 ] },
 
    }
}
