using LiquidLabs.Data.Interfaces;
using LiquidLabs.Models.Entities;

namespace LiquidLabs.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IJsonPlaceholderService _apiService;
        private readonly ILogger<UserService> _logger;

        public UserService(
            IUserRepository repository,
            IJsonPlaceholderService apiService,
            ILogger<UserService> logger)
        {
            _repository = repository;
            _apiService = apiService;
            _logger = logger;
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("Fetching user data for ID: {Id}", id);

           
                var cachedUser = await _repository.GetByIdAsync(id);

                if (cachedUser != null)
                {
                    _logger.LogInformation("User data found in cache for ID: {Id}", id);
                    return cachedUser;
                }

           
                _logger.LogInformation("User data not in cache, fetching from API for ID: {Id}", id);

                var apiUser = await _apiService.FetchUserByIdAsync(id);

                if (apiUser == null)
                {
                    _logger.LogWarning("Failed to fetch user data from API for ID: {Id}", id);
                    return null;
                }


                var savedUser = await _repository.InsertAsync(apiUser);

                _logger.LogInformation("User data cached successfully for ID: {Id}", id);

                return savedUser;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving user data for ID: {Id}", id);
                throw;
            }
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            try
            {
                _logger.LogInformation("Fetching all user data");


                var cachedUsers = await _repository.GetAllAsync();

                if (cachedUsers.Any())
                {
                    _logger.LogInformation("Returning {Count} users from cache", cachedUsers.Count);
                    return cachedUsers;
                }

 
                _logger.LogInformation("No users in cache, fetching all from API");

                var apiUsers = await _apiService.FetchAllUsersAsync();

                if (!apiUsers.Any())
                {
                    _logger.LogWarning("No users returned from API");
                    return new List<User>();
                }

        
                foreach (var user in apiUsers)
                {
                    await _repository.InsertAsync(user);
                }

                _logger.LogInformation("Successfully cached {Count} users from API", apiUsers.Count);

                return apiUsers;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving all the user data");
                throw;
            }
        }
    }
}
