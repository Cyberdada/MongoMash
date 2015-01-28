using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json.Linq;

using MongoDaDa.Api;

namespace MongoDaDa.Api.Controllers
{
    public class BookingController : ApiController
    {
        // GET: api/Booking
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Booking/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Booking
        public HttpResponseMessage Post([FromBody]JToken jsonbody)
        {
            //Clever and classless and free 
            // but still fu**ing peasants ? 
 
            string json = jsonbody.ToString();
            new Data.Base().Save(json);
            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        // PUT: api/Booking/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Booking/5
        public void Delete(int id)
        {
        }
    }
}
