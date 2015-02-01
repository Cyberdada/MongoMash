using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;

namespace MongoDaDa.Model
{
    public class AdHocQuery
    {
        public List<string> Fields { get; set; }
        public string Query { get; set; }
    }
}