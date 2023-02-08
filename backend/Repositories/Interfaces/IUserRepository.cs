using Lupy.Models;

namespace Lupy.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserModel>?> FindAll();
        Task<UserModel?> FindById(int id);
        Task<UserModel> Create(UserModel animal);
        Task<UserModel> Update(UserModel animal, int id);
        Task<bool> Delete(int id);
    }
}
