﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;


namespace MongoDaDa.Model
{
   public class PersonBase
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Name { get; set; }

    }
}
