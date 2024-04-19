using Microsoft.AspNetCore.Mvc;
using OpenQuantTest.Models;
using OpenQuantTest.Repositories;
using OpenQuantTest.Repositories.Interfaces;

namespace OpenQuantTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            this._accountRepository = accountRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<AccountModel>>> FindAll()
        {
           List<AccountModel> accounts = await _accountRepository.FindAll();
           return Ok(accounts);
        }
    }
}
