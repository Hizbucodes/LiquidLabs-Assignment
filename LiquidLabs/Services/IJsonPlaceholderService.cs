using LiquidLabs.Models.Entities;

namespace LiquidLabs.Services
{
    public interface IJsonPlaceholderService
    {
        Task<User?> FetchUserByIdAsync(int id);
        Task<List<User>> FetchAllUsersAsync();
    }
}
