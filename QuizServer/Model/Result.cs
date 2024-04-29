using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Collections.Generic;

namespace QuizServer.Model
{
    public class Result
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId resultID { get; set; }
        public string userName { get; set; }
        public string categoryName { get; set; }
        public string userPhoneNumber { get; set; }

        // Dictionary to store chosen options
        public Dictionary<string, string> ChoseOption { get; set; } = new Dictionary<string, string>();

    }
}
