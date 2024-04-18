using OpenQuantTest.Models;

namespace OpenQuantTest.Repositories.Interfaces
{
    public interface ITransactionRepository
    {
        Task<List<TransactionModel>> FindAllTransactionsByAccountId(int id);
    }
}
