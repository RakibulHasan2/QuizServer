using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace QuizServer.Model
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId userID{ get; set; }
        public string userName { get; set; }
        public string userAddress{ get; set; }
        public string phoneNumber { get; set; }
        public string role { get; set; }
        public string pass { get; set; }
        public string confirmPass { get; set; }
    }
}
