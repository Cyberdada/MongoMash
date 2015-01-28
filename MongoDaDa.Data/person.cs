using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDaDa.Model;
using MongoDB.Driver.Builders;

namespace MongoDaDa.Data
{
    

   public class Person:Base
    {
       const string MyName = "Person";

       public void SaveBasics()
       {

           
           var collection = GetCollection(MyName);
           
           //Rensa bort gammalt skräp
           collection.Drop();


           var firstId = ObjectId.GenerateNewId();
           collection.Save(new PersonDetails 
           { 
               Id = firstId, 
               Name = "Magnus", 
               DateOfBirth = new DateTime(1969, 03, 20) 
           });
           
           collection.Save(new PersonDetails 
           {
               Id= firstId, 
               Adress = new List<Model.Adress> 
               {
                   new Model.Adress {Street = "Vestmannabraut",Nr = 72,City = "Vestmannaeyjar",Country = "Island"}, 
                   new Model.Adress {Street = "Funafold",Nr = 47,City = "Reykjavik",Country = "Island"}, 
                   new Model.Adress {Street = "Linnegatan",Nr = 26,City = "Göteborg",Country = "Sverige"}, 
                   new Model.Adress {Street = "Snäckvägen",Nr = 26,City = "Göteborg",Country = "Island"}, 
               }
           });

           var ActorPerson = new Model.PersonDetails
           {
               Name = "Humpfrey Bogart",
               DateOfBirth = new DateTime(1920, 02, 20),
               Id = ObjectId.GenerateNewId(),
               Adress = new List<Model.Adress>
               {
                 new Model.Adress { Street="Bogart Street", Nr=4, City="Los Angeles",Country="USA"}, 
                 new Model.Adress {Street="Bogart Bungalow", Nr=12, City="Acapulco",  Country="Mexico" },
                 new Model.Adress {Street="Bogart Street", Nr=4, City="Boston", Country="USA"}
               }
           };
           collection.Save(ActorPerson);




           collection.Save(new PersonDetails { Name = "Eivert", Id = ActorPerson.Id });

           collection.Insert(new PersonDetails { 
               Name = "Vlad Tepes", 
               Id = ObjectId.GenerateNewId(), 
               DateOfBirth = new DateTime(1969, 3, 20) }
               );


           BsonDocument AnotherGuy = new BsonDocument {
                { "Name", "Nick Cave" },
                { "Adress", "A small town in England" }, 
                {"Occupation", "Musician"}, 
                {"_id",  ObjectId.GenerateNewId()}
           };

           collection.Save(AnotherGuy);


           
           //AnotherGuy 
           //luktar som json --- 
           // Där väljer jag att helt strunta i autoserialiseringen och skapa ett BsonDokument direkt
           //om man har ett gigantiskt json doc som man vill dunka in så kan man göra så här::
           //string json = LäsFetJsonFil()
           //BsonDocument document = BsonDocument.Parse(json);


           //Ej angivna textvärden får null bydefault + 
           // ej angivna numeriska fält får 0 
           // Save updaterar existerande post, 
           // Insert Failar om post existerar
           // Kolla in date of birth i db....
       }
      
        public void UpdateBasics()
        {
            // Update -en fråga, + det som ska uppdateras
            var collection = GetCollection(MyName);

      

            collection.Update(
                new QueryDocument { { "Name", "Vlad Tepes" } },
                new UpdateDocument { { "$set", new BsonDocument("Adress", "SnackBaren") } }
            );

            // Id vs _id 
            
            //Adress felstavat , kommer skapa ett nytt adress fält
            // Större frihet innbär större ansvar. 
            // Kan var bättre att köra typat... 


            var typedCollection = GetCollection(this);


            var query = Query<PersonDetails>.EQ(e => e.Name, "Nick Cave");
            var update = Update<PersonDetails>.Set(e => e.Name, "Gonzo"); // update modifiers
            collection.Update(query, update);


            var query2 = Query<PersonDetails>.EQ(e => e.Name, "Magnus");
            var update2 = Update<PersonDetails>.Set(e => e.Adress, new List<Model.Adress>()); // update modifiers
            collection.Update(query2, update2);

            //nästa skulle inte fungera om vi inte tar bort adresserna som vi tilldelade förut
            // härnäst väljer vi att arbeta otypat med hjälp av en json sträng som vi serialiserar
            var jsonQuery = "{ Name :{ $in: [ 'Vlad Tepes','Gonzo']}}";
            BsonDocument doc = MongoDB.Bson.Serialization
                   .BsonSerializer
                   .Deserialize<BsonDocument>(jsonQuery);

            collection.Update(
                new QueryDocument(doc),
                new UpdateDocument { { "$set", new BsonDocument("Adress", new BsonArray()) }},UpdateFlags.Multi 
            );


            var query3 = Query<PersonDetails>.In(e => e.Name, new List<string> {"Vlad Tepes", "Gonzo"});
            var update3 = Update<PersonDetails>.AddToSet(
                e => e.Adress,
             new Model.Adress { Street = "Gonzo Street", Nr = 4, City = "Las Vegas", Country = "USA" }); // update modifiers
            collection.Update(query3, update3);



        }

       //TODO!!
       public void LiteLinqGrejs()
        {

        }

        public void TidenÄrUrLed()
        {
            //    c# driver by default (without extra settings) 
            //saving local dates as utc date into database 
           //(date - time zone offset) but reading back without any action (so, utc date).
        }

       public void ReadingStuff()
        {


            var PersonCollection = GetCollection(MyName);


           // Vi kan välja att strunta i alla objekt och bara agera 
           // som någonslags "pass through" var uppgift är att ställa frågor emot DB + 
           //ev. köra nestlade loopar för joins.  
            var docs = PersonCollection.FindAs<BsonDocument>(Query.GT("_id", "000000000000000")).ToList();

           // Eller så kan vi typa allt ihop, men då måste vi anpassa oss. 
           // det är svårt när ett fält ibland används som en array, 
           // och ibland som en sträng....

           var personaxs = PersonCollection.FindAllAs<PersonDetails>(); 
            var personlist2 = personaxs.ToList();
           var WhatIsTheCatch = personlist2[2].CatchAll;

        }



    }
}
