using Lupy.Models;
using Lupy.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lupy.Controllers
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

        [HttpGet]
        public async Task<ActionResult<List<UserModel>?>> FindAll()
        {
            List<UserModel>? animals = await _userRepository.FindAll();
            return Ok(animals);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel?>> FindById(int id)
        {
            UserModel? animal = await _userRepository.FindById(id);
            return Ok(animal);
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> Create([FromBody] UserModel UserModel)
        {
            UserModel animal = await _userRepository.Create(UserModel);
            return Ok(animal);
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<UserModel>> Update([FromBody] UserModel UserModel, int id)
        {
            UserModel animal = await _userRepository.Update(UserModel, id);
            return Ok(animal);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            bool result = await _userRepository.Delete(id);
            return Ok(result);
        }
    }
}
