using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenQuantTest.Models;

namespace OpenQuantTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpGet]
        public ActionResult<List<UserModel>> FindAll()
        {
            return Ok();
        }
    }
}
