using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using QuizServer.Model;
using QuizServer.Repositories;

namespace QuizServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        private readonly IResultRepository _resultRepository;

        public ResultController(IResultRepository resultRepository)
        {
             _resultRepository = resultRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Result result)
        {
            var id = await _resultRepository.Create(result);
            return new JsonResult(id.ToString());
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var r = await _resultRepository.Get(ObjectId.Parse(id));
            return new JsonResult(r);
        }


        [HttpGet("Fetch")]
        public async Task<IActionResult> GetAll()
        {
            var r = await _resultRepository.GetAll();
            return new JsonResult(r);
        }


        [HttpGet("getByCatName/{catName}")]
        public async Task<IActionResult> GetByCatName(string catName)
        {
            var r = await _resultRepository.GetByCatName(catName);
            return new JsonResult(r);
        }

    }
}
