using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenQuantTest.Models;
using OpenQuantTest.Repositories;
using OpenQuantTest.Repositories.Interfaces;

namespace OpenQuantTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;


        public UserController(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> FindAll()
        {
            List<UserModel> users = await _userRepository.FindAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<UserModel>>> FindById(int id)
        {
            UserModel user = await _userRepository.FindById(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<List<UserModel>>> save([FromBody] UserModel user)
        {
            UserModel userSaved = await _userRepository.Save(user);
            return Ok(userSaved);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<UserModel>>> update(int id, [FromBody] UserModel user)
        {
            UserModel userSaved = await _userRepository.Update(id, user);
            return Ok(userSaved);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<UserModel>>> delete(int id)
        {
           await _userRepository.delete(id);
            return Ok(true);
        }


    }
}
