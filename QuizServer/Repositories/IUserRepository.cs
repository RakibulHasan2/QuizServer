using MongoDB.Bson;
using QuizServer.Model;

namespace QuizServer.Repositories
{
    public interface IUserRepository
    {
        Task<ObjectId> Create(User users);
        Task<User> Get(ObjectId objectId);
        Task<IEnumerable<User>> GetAll();
        Task<IEnumerable<User>> GetByName(string Name);

        Task<bool> Update(ObjectId objectId, User users);

        Task<bool> Delete(ObjectId objectId);
   
    }
}
