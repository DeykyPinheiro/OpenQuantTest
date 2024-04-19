using Microsoft.AspNetCore.Mvc;
using OpenQuantTest.Models;

namespace OpenQuantTest.Repositories.Interfaces
{
    public interface IAccountRepository
    {

        Task<List<AccountModel>> FindAll();

        Task<AccountModel> FindById(int id);

        Task<AccountModel> Save(AccountModel user);

        Task<AccountModel> Update(int id, decimal amount);
    }
}
