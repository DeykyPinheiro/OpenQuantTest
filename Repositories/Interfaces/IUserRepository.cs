using OpenQuantTest.Models;

namespace OpenQuantTest.Repositories.Interfaces
{
    public interface IUserRepository
    {

        Task<List<UserModel>> FindAll();

        Task<UserModel> FindById(int id);

        Task<UserModel> Save(UserModel user);

        Task<UserModel> Update(int id , UserModel user);

        Task<bool> delete(int id);

    }
}
