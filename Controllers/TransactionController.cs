using Microsoft.AspNetCore.Mvc;
using OpenQuantTest.Models;
using OpenQuantTest.Repositories;
using OpenQuantTest.Repositories.Interfaces;
using OpenQuantTest.Services;

namespace OpenQuantTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : Controller
    {
        private readonly ITransactionRepository _transactionRepository;

        private readonly TransactionService _transactionService;


        public TransactionController(ITransactionRepository transactionRepository,
             TransactionService transactionService)
        {
            this._transactionRepository = transactionRepository;
            this._transactionService = transactionService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<TransactionModel>>> FindTransactionsByAccountId(int id)
        {
            List<TransactionModel> transactions = await _transactionRepository.FindAllTransactionsByAccountId(id);
            return Ok(transactions);
        }

        [HttpPost("Deposit/{id}")]
        public async Task<ActionResult<TransactionModel>> Deposit(int id, [FromBody] decimal amount)
        {
            TransactionModel transaction = await _transactionService.Deposit(id, amount);
            return transaction;
        }

        [HttpPost("Payer/{payerId}/receiver/{receiverId}")]
        public async Task<ActionResult<TransactionModel>> Transfer(int payerId, int receiverId, [FromBody] decimal amount)
        {
            TransactionModel transaction = await _transactionService.Transfer(payerId, receiverId ,amount);
            return transaction;
        }

    }
}
