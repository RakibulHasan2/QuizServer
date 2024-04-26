using MongoDB.Bson;
using QuizServer.Model;

namespace QuizServer.Repositories
{
    public interface IQuestionRepository
    {
        Task<ObjectId> Create(Question question);
        Task<Question> Get(ObjectId objectId);
        Task<IEnumerable<Question>> GetAll();

        Task<IEnumerable<Question>> GetByCatName(string catName);

        Task<bool> Update(ObjectId objectId, Question question);

        Task<bool> Delete(ObjectId objectId);
    }
}
