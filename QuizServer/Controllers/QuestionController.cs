using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using QuizServer.Model;
using QuizServer.Repositories;

namespace QuizServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionController(IQuestionRepository questoinRepository)
        {
           _questionRepository = questoinRepository;
        }


        [HttpPost]
        public async Task<IActionResult> Create(Question question)
        {
            var id = await _questionRepository.Create(question);
            return new JsonResult(id.ToString());
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var q = await _questionRepository.Get(ObjectId.Parse(id));
            return new JsonResult(q);
        }

        [HttpGet("getByCatName/{catName}")]
        public async Task<IActionResult> GetByName(string catName)
        {
            var q = await _questionRepository.GetByCatName(catName);
            return new JsonResult(q);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Update(string id, Question question)
        {
            var q = await _questionRepository.Update(ObjectId.Parse(id), question);
            return new JsonResult(q);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var q =  await _questionRepository.Delete(ObjectId.Parse(id));
            return new JsonResult(q);
        }

        [HttpGet("Fetch")]
        public async Task<IActionResult> GetAll()
        {
            var q= await _questionRepository.GetAll();
            return new JsonResult(q);
        }
    }
}
