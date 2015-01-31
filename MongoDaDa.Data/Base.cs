
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.IO;
using MongoDB.Driver.Builders;
using MongoDaDa.Model;

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

        

        protected MongoDatabase GetDatabase()
        {
            const string ConnectionString = "mongodb://localhost";
            const string Database = "Demo";

            var client = new MongoClient(ConnectionString);
            var server = client.GetServer();
    
           return server.GetDatabase(Database);

        }

        public string Find(AdHocQuery adhoc, string collectionName)
        {
            return AdHoc(adhoc.Query, adhoc.Fields, 0, 0, collectionName);
            //throw new NotImplementedException();
        }


        public void Save(string json, string collectionName)
        {
            var collection = GetCollection(collectionName);

            BsonArray docs =
            MongoDB.Bson.Serialization.BsonSerializer.Deserialize<BsonArray>(json);
            
            foreach(var itm in docs)
            {
                collection.Save(BsonDocument.Create(itm));
            }
      
        }



        private string AdHoc(string jsonquery, List<string> fields, int limit, int skip, string collection)
        {

          BsonDocument query = MongoDB.Bson.Serialization.BsonSerializer.Deserialize<BsonDocument>(jsonquery);
            QueryDocument queryDoc = new QueryDocument(query);

            var result = FindByQueryLimitFields(queryDoc, collection, fields.ToArray())
                .SetLimit(limit)
                .SetSkip(skip)
               .ToJson(new JsonWriterSettings { OutputMode = JsonOutputMode.Shell });

            return result;
        }

        private MongoCursor FindByQueryLimitFields(IMongoQuery query, string collection, string[] fields)
        {

            MongoDatabase db = GetDatabase();
            var col = db.GetCollection(collection);
            var cursor = col.Find(query);
            cursor.SetFields(Fields.Include(fields));
            return cursor;
       }


        public string FindById(string id, string CollectionName)
        {
            var query = Query.And(
            Query.EQ("_id", id));

            MongoDatabase db = GetDatabase();
            var col = db.GetCollection(CollectionName);
            var cursor = col.FindOne(query);
            return cursor.ToString();

        }
    }
}
