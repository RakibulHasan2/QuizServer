using MongoDB.Bson;
using QuizServer.Model;

namespace QuizServer.Repositories
{
    public interface IResultRepository
    {
        Task<ObjectId> Create(Result result);
        Task<Result> Get(ObjectId objectId);
        Task<IEnumerable<Result>> GetAll();
        Task<IEnumerable<Result>> GetByCatName(string Name);
        Task<bool> Update(ObjectId objectId, Result result);
    }
}
