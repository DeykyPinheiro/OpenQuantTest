using Microsoft.EntityFrameworkCore;
using OpenQuantTest.Data;
using OpenQuantTest.Models;
using OpenQuantTest.Repositories.Interfaces;

namespace OpenQuantTest.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly AppDbContext _dbContext;

        public TransactionRepository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public async Task<List<TransactionModel>> FindAllTransactionsByAccountId(int id)
        {
           return (List<TransactionModel>)_dbContext.Transactions.Where(t => t.Payer.Account.Id == id || t.Receiver.Account.Id == id);
        }
    }
}
