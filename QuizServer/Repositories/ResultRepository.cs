﻿using MongoDB.Bson;
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

        public async Task<String> Create(Result result)
        {
            await _results.InsertOneAsync(result);
            return result.resultID;
        }

        public Task<Result> Get(String objectId)
        {
            var filter = Builders<Result>.Filter.Eq(x => x.resultID, objectId);
            var result = _results.Find(filter).FirstOrDefaultAsync();
            return result;
        }

        public async Task<IEnumerable<Result>> GetAll()
        {
            return await _results.Find(_ => true)  .ToListAsync();
        }

        public async Task<IEnumerable<Result>> GetByCatName(string Name)
        {
            var filter = Builders<Result>.Filter.Eq(x => x.categoryName, Name);
            var r = await _results.Find(filter).ToListAsync();
            return r;
        }
        public async Task<bool> Update(String objectId, Result result)
        {
            var filter = Builders<Result>.Filter.Eq(x => x.resultID, objectId);
            var update = Builders<Result>.Update
                .Set(x => x.score, result.score);
            var r = await _results.UpdateOneAsync(filter, update);
            return r.ModifiedCount == 1;
        }
    }
}
