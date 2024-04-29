using MongoDB.Bson;
using MongoDB.Driver;
using QuizServer.Model;

namespace QuizServer.Repositories
{
    public class ResultRepository : IResultRepository
    {

        private readonly IMongoCollection<Result> _results;

        public ResultRepository(IMongoClient client)
        {
            var database = client.GetDatabase("Quiz_APP");
            var collection = database.GetCollection<Result>(nameof(Result));
            _results = collection;
        }

        public async Task<ObjectId> Create(Result result)
        {
            await _results.InsertOneAsync(result);
            return result.resultID;
        }

        public Task<Result> Get(ObjectId objectId)
        {
            var filter = Builders<Result>.Filter.Eq(x => x.resultID, objectId);
            var result = _results.Find(filter).FirstOrDefaultAsync();
            return result;
        }

        public async Task<IEnumerable<Result>> GetAll()
        {
            var r = await _results.Find(_ => true).ToListAsync();
            return r;
        }

        public async Task<IEnumerable<Result>> GetByCatName(string Name)
        {
            var filter = Builders<Result>.Filter.Eq(x => x.categoryName, Name);
            var r = await _results.Find(filter).ToListAsync();
            return r;
        }
    }
}
