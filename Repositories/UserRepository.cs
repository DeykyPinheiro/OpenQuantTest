using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using OpenQuantTest.Data;
using OpenQuantTest.Models;
using OpenQuantTest.Repositories.Interfaces;

namespace OpenQuantTest.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public async Task<List<UserModel>> FindAll()
        {
            return await _dbContext.Users
                            .Include(user => user.Account)
                            .ToListAsync();
        }

        public async Task<UserModel> FindById(int id)
        {
            return await _dbContext.Users
                 .Include(user => user.Account)
                            .FirstOrDefaultAsync(u => u.Id == id);

        }



        public async Task<UserModel> Save(UserModel user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<UserModel> Update(int id, UserModel user)
        {

            UserModel userId = await FindById(id);

            if (userId == null)
            {
                throw new Exception($"Usuario de Id: {id} não Encontrado.");
            }

            userId.Name = user.Name;
            userId.Email = user.Email;

            _dbContext.Update(userId);
            await _dbContext.SaveChangesAsync();

            return userId;
        }

        public async Task delete(int id)
        {
            UserModel userId = await FindById(id);

            if (userId == null)
            {
                throw new Exception($"Usuario de Id: {id} não Encontrado.");
            }

            _dbContext.Users.Remove(userId);
            _dbContext.SaveChanges();
        }

    }
}
