using Lupy.Data;
using Lupy.Models;
using Lupy.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lupy.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly LupyDBContext _dbContext;
        public UserRepository(LupyDBContext lupyDBContext)
        {
            _dbContext = lupyDBContext;
        }
        public async Task<List<UserModel>?> FindAll()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<UserModel?> FindById(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UserModel> Create(UserModel user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<UserModel> Update(UserModel user, int id)
        {
            UserModel userById = await FindById(id);

            if(userById == null)
            {
                throw new Exception($"User with ID: {id} not found");
            }

            userById.Name = user.Name;
            userById.Email = user.Email;
            userById.Cellphone = user.Cellphone;
            userById.Password = user.Password;
            userById.DtUpdated = DateTime.Now;
            userById.IsActive = user.IsActive;

            _dbContext.Users.Update(userById);
            await _dbContext.SaveChangesAsync();

            return userById;
        }

        public async Task<bool> Delete(int id)
        {
            UserModel userById = await FindById(id);

            if (userById == null)
            {
                throw new Exception($"User with ID: {id} not found");
            }

            _dbContext.Users.Remove(userById);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
