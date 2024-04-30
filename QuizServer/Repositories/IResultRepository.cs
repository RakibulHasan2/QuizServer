using MongoDB.Bson;
using QuizServer.Model;

namespace QuizServer.Repositories
{
    public interface IResultRepository
    {
        Task<String> Create(Result result);
        Task<Result> Get(String objectId);
        Task<IEnumerable<Result>> GetAll();
        Task<IEnumerable<Result>> GetByCatName(string Name);
        Task<bool> Update(String objectId, Result result);
    }
}
