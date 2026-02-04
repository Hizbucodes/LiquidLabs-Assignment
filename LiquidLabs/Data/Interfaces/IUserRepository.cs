using LiquidLabs.Models.Entities;

namespace LiquidLabs.Data.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(int id);
        Task<User?> GetByUsernameAsync(string username);
        Task<List<User>> GetAllAsync();
        Task<User> InsertAsync(User user);
        Task<User> UpdateAsync(User user);
        Task<bool> ExistsAsync(int id);
    }
}
