﻿using Microsoft.EntityFrameworkCore;
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
            return await _dbContext.Transactions
                             .Where(t => t.Payer.Id == id || t.Receiver.Id == id)
                             .Include(t => t.Payer)
                             .Include(t => t.Receiver)
                             .ToListAsync();
        }

        public async Task<TransactionModel> Save(TransactionModel transaction)
        {

            await _dbContext.Transactions.AddAsync(transaction);
            await _dbContext.SaveChangesAsync();

            return transaction;
        }
    }
}
