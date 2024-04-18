using OpenQuantTest.Models;

namespace OpenQuantTest.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        Task<List<AccountModel>> FindAll();
    }
}
