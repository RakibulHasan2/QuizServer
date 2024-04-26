using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace QuizServer.Model
{
    public class Question
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId questionID { get; set; }
        public string questionCategory { get; set; }
        public string question { get; set; }
        public string option1 { get; set; }
        public string option2 { get; set; }
        public string option3 { get; set; }
        public string option4 { get; set; }
        public string answer { get; set; }

    }
}
