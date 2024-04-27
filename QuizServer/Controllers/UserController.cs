using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using QuizServer.Model;
using QuizServer.Repositories;

namespace QuizServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            var id = await _userRepository.Create(user);
            return new JsonResult(id.ToString());
        }

        [HttpGet("login")]
        public async Task<IActionResult> Login(string phoneNumber, string pass)
        {
            var user = await _userRepository.Login(phoneNumber, pass);
            return new JsonResult(user);
        }


        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var user = await _userRepository.Get(ObjectId.Parse(id));
            return new JsonResult(user);
        }

        [HttpGet("getByName/{name}")]
        public async Task<IActionResult> GetByName(string Name)
        {
            var user = await _userRepository.GetByName(Name);
            return new JsonResult(user);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Update(string id,User user)
        {
            var User = await _userRepository.Update(ObjectId.Parse(id), user);
            return new JsonResult(User);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userRepository.Delete(ObjectId.Parse(id));
            return new JsonResult(user);
        }

        [HttpGet("Fetch")]
        public async Task<IActionResult> GetAll()
        {
            var user = await _userRepository.GetAll();
            return new JsonResult(user);
        }
    }
}
