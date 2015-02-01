using System;
using System.Text.RegularExpressions;

namespace MongoDaDa.Formatter
{
    public class BsonToJson
    {

        public static string RinseBsonOutput(string json )
        {
            return ParseOutIsoDate(ParseOutObjectId(json));
        }
       
        private static string ParseOutObjectId(string json)
        {

            foreach (Match match in Regex.Matches(json, @"ObjectId\(([^\)]*)\)"))
            {
                var result = match.Value;
                var id = result.Replace("ObjectId(", string.Empty).Replace(")", String.Empty);
                json = json.Replace(result, id);
            }
            return json;
        }

        // ISODate("2012-12-19T06:01:17.171Z")
        private static string ParseOutIsoDate(string json)
        {

            foreach (Match match in Regex.Matches(json, @"ISODate\(([^\)]*)\)"))
            {
                var result = match.Value;
                var id = result.Replace("ISODate(", string.Empty).Replace(")", String.Empty);
                json = json.Replace(result, id);
            }
            return json;
        }
    }
}
