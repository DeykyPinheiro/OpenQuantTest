using Microsoft.AspNetCore.Mvc;
using OpenQuantTest.Models;
using OpenQuantTest.Repositories;
using OpenQuantTest.Repositories.Interfaces;

namespace OpenQuantTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : Controller
    {
        private readonly ITransactionRepository _transactionRepository;


        public TransactionController(ITransactionRepository transactionRepository)
        {
            this._transactionRepository = transactionRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<TransactionModel>>> FindTransactionsByAccountId(int id)
        {
            List<TransactionModel> transactions = await _transactionRepository.FindAllTransactionsByAccountId(id);
            return Ok(transactions);
        }

    }
}
