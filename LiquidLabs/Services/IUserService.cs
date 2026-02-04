using LiquidLabs.Models.Entities;

namespace LiquidLabs.Services
{
    public interface IUserService
    {
        Task<User?> GetUserByIdAsync(int id);
        Task<List<User>> GetAllUsersAsync();
    }
}
