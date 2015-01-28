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



namespace MongoDaDa.Data
{
    public class Base
    {

        protected MongoCollection GetCollection(string collection)
        {
         var mongo = GetDatabase();
         return  mongo.GetCollection(collection);
       }
       
        protected MongoCollection<T> GetCollection<T>(T item) where  T:class
        {
            var mongo = GetDatabase();
            return mongo.GetCollection<T>(item.GetType().Name);
        }

        public void Save(string json) 
        {
            var collection = GetCollection("TwilightZone");
            collection.Save(BsonDocument.Parse(json));
           
        }
        

        protected MongoDatabase GetDatabase()
        {
            const string ConnectionString = "mongodb://localhost";
            const string Database = "Demo";

            var client = new MongoClient(ConnectionString);
            var server = client.GetServer();
       

           return server.GetDatabase(Database);

        }
    }
}
