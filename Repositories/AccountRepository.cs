using Microsoft.EntityFrameworkCore;
using OpenQuantTest.Data;
using OpenQuantTest.Models;
using OpenQuantTest.Repositories.Interfaces;

namespace OpenQuantTest.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDbContext _dbContext;

        public AccountRepository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public async Task<List<AccountModel>> FindAll()
        {
            return await _dbContext.Accounts.ToListAsync();
        }

        public async Task<AccountModel> FindById(int id)
        {
            return await _dbContext.Accounts.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<AccountModel> Save(AccountModel account)
        {
            await _dbContext.Accounts.AddAsync(account);
            await _dbContext.SaveChangesAsync();

            return account;
        }

        public async Task<AccountModel> Update(int id, decimal amount)
        {
            AccountModel account = await FindById(id);

            if (account == null)
            {
                throw new Exception($"Conta de Id: {id} não Encontrada.");
            }

            account.Balance += amount;

            _dbContext.Update(account);
            await _dbContext.SaveChangesAsync();

            return account;
        }
    }

   
}
