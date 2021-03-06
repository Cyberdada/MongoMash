﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

using Newtonsoft.Json.Linq;
using MongoDaDa.Model;
using MongoDaDa.Api;
using MongoDaDa.Formatter;
using System.Text;

namespace MongoDaDa.Api.Controllers
{
    public class TwilightZoneController : ApiController
    {

        const string CollectionName = "TwilightZone";
  

        
        public string Get(string id)
        {
            
             return BsonToJson.RinseBsonOutput
                 (new Data.Base().FindById(id, CollectionName));
        }

        [HttpPost]
        public HttpResponseMessage Search([FromBody] JToken jsonbody)
        {
            AdHocQuery adhoc = new AdHocQuery()
            {
                Fields = jsonbody["fields"].ToObject<string[]>().ToList<string>(),
                Query = jsonbody["query"].ToString()
            };

            string myJson = BsonToJson.RinseBsonOutput
                (new Data.Base().Find(adhoc,  CollectionName));

            var response = this.Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(myJson, Encoding.UTF8, "application/json");
            return response;
        }

         [HttpPost]
        public HttpResponseMessage Add([FromBody]JToken jsonbody)
        {
            //Clever and classless and free?
           
            string json = jsonbody.ToString();
            new Data.Base().Save(json, CollectionName);
            return new HttpResponseMessage(HttpStatusCode.Created);
        }
    }
}
