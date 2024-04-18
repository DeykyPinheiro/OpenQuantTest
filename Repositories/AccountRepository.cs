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
       
    }
}
