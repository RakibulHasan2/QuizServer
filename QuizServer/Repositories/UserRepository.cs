using MongoDB.Bson;
using MongoDB.Driver;
using QuizServer.Model;

namespace QuizServer.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _users;

        public UserRepository(IMongoClient client)
        {
            var database = client.GetDatabase("Quiz_APP");
            var collection = database.GetCollection<User>(nameof(User));
            _users = collection;
        }

        public async Task<ObjectId> Create(User user)
        {
            await _users.InsertOneAsync(user);
            return user.userID;
        }

        public async Task<bool> Delete(ObjectId objectId)
        {
            var filter = Builders<User>.Filter.Eq(x => x.userID, objectId);
            var result = await _users.DeleteOneAsync(filter);
            return result.DeletedCount == 1;
        }

        public Task<User> Get(ObjectId objectId)
        {
            var filter = Builders<User>.Filter.Eq(x => x.userID, objectId);
            var user = _users.Find(filter).FirstOrDefaultAsync();
            return user;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var user = await _users.Find(_ => true).ToListAsync();
            return user;
        }

        public async Task<IEnumerable<User>> GetByName(string Name)
        {
            var filter = Builders<User>.Filter.Eq(x => x.userName, Name);
            var user = await _users.Find(filter).ToListAsync();
            return user;
        }

        public async Task<bool> Update(ObjectId objectId, User user)
        {
            var filter = Builders<User>.Filter.Eq(x => x.userID, objectId);
            var update = Builders<User>.Update
                .Set(x => x.userName, user.userName)
                .Set(x => x.phoneNumber, user.phoneNumber)
                .Set(x => x.userAddress, user.userAddress);

            var result = await _users.UpdateOneAsync(filter, update);
            return result.ModifiedCount == 1;

        }

    }
}
