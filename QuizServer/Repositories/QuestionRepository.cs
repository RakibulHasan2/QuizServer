using MongoDB.Bson;
using MongoDB.Driver;
using QuizServer.Model;
using System.Xml.Linq;

namespace QuizServer.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly IMongoCollection<Question> _questions;


        public QuestionRepository(IMongoClient client)
        {
            var database = client.GetDatabase("Quiz_APP");
            var collection = database.GetCollection<Question>(nameof(Question));
            _questions = collection;
        }

        public async Task<ObjectId> Create(Question question)
        {
            await _questions.InsertOneAsync(question);
            return question.questionID;
        }


        public async Task<bool> Delete(ObjectId objectId)
        {
            var filter = Builders<Question>.Filter.Eq(x => x.questionID, objectId);
            var result = await _questions.DeleteOneAsync(filter);
            return result.DeletedCount == 1;
        }


        public Task<Question> Get(ObjectId objectId)
        {
            var filter = Builders<Question>.Filter.Eq(x => x.questionID, objectId);
            var q = _questions.Find(filter).FirstOrDefaultAsync();
            return q;
        }

        public async Task<IEnumerable<Question>> GetAll()
        {
            var q = await _questions.Find(_ => true).ToListAsync();
            return q;
        }
        public async Task<IEnumerable<Question>> GetByCatName(string catName)
        {
            var filter = Builders<Question>.Filter.Eq(x => x.questionCategory, catName);
            var q = await _questions.Find(filter).ToListAsync();
            return q;
        }

        public async Task<bool> Update(ObjectId objectId, Question question)
        {
            var filter = Builders<Question>.Filter.Eq(x => x.questionID, objectId);
            var update = Builders<Question>.Update
                .Set(x => x.questionCategory, question.questionCategory)
                .Set(x => x.question, question.question)
                .Set(x => x.option1, question.option1)
                .Set(x => x.option2, question.option2)
                .Set(x => x.option3, question.option3)
                .Set(x => x.option4, question.option4)
                .Set(x => x.answer, question.answer);

            var result = await _questions.UpdateOneAsync(filter, update);
            return result.ModifiedCount == 1;
        }
    }
}
