using LiquidLabs.Extensions;
using LiquidLabs.Models.DTOs.JsonPlaceholder;
using LiquidLabs.Models.Entities;
using Newtonsoft.Json;

namespace LiquidLabs.Services
{
    public class JsonPlaceholderService : IJsonPlaceholderService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly ILogger<JsonPlaceholderService> _logger;

        public JsonPlaceholderService(
            HttpClient httpClient,
            IConfiguration configuration,
            ILogger<JsonPlaceholderService> logger)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<User?> FetchUserByIdAsync(int id)
        {
            try
            {
                var baseUrl = _configuration["JsonPlaceholder:BaseUrl"];
                var url = $"{baseUrl}/users/{id}";

                _logger.LogInformation("Fetching user data from JSONPlaceholder API for ID: {Id}", id);

                var response = await _httpClient.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogWarning("Failed to fetch user data for ID: {Id}. Status: {StatusCode}",
                        id, response.StatusCode);
                    return null;
                }

                var jsonContent = await response.Content.ReadAsStringAsync();
                var userDto = JsonConvert.DeserializeObject<UserDto>(jsonContent);

                if (userDto == null)
                {
                    _logger.LogWarning("Failed to deserialize API response for user ID: {Id}", id);
                    return null;
                }

              
                var user = userDto.ToEntity();

                _logger.LogInformation("Successfully fetched and mapped user data for ID: {Id}", id);

                return user;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "HTTP error while fetching user data for ID: {Id}", id);
                throw;
            }
            catch (JsonException ex)
            {
                _logger.LogError(ex, "JSON deserialization error for user ID: {Id}", id);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error while fetching user data for ID: {Id}", id);
                throw;
            }
        }

        public async Task<List<User>> FetchAllUsersAsync()
        {
            try
            {
                var baseUrl = _configuration["JsonPlaceholder:BaseUrl"];
                var url = $"{baseUrl}/users";

                _logger.LogInformation("Fetching all users from JSONPlaceholder API");

                var response = await _httpClient.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogWarning("Failed to fetch all users. Status: {StatusCode}",
                        response.StatusCode);
                    return new List<User>();
                }

                var jsonContent = await response.Content.ReadAsStringAsync();
                var userDtos = JsonConvert.DeserializeObject<List<UserDto>>(jsonContent);

                if (userDtos == null || !userDtos.Any())
                {
                    _logger.LogWarning("No users returned from API or deserialization failed");
                    return new List<User>();
                }

             
                var users = userDtos.ToEntities();

                _logger.LogInformation("Successfully fetched and mapped {Count} users from API", users.Count);

                return users;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "HTTP error while fetching all users");
                throw;
            }
            catch (JsonException ex)
            {
                _logger.LogError(ex, "JSON deserialization error while fetching all users");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error while fetching all users");
                throw;
            }
        }
    }
}
