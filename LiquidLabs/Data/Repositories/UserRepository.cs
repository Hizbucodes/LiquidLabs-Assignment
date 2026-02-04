using LiquidLabs.Data.Interfaces;
using LiquidLabs.Extensions;
using LiquidLabs.Models.Entities;
using Microsoft.Data.SqlClient;

namespace LiquidLabs.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(IConfiguration configuration, ILogger<UserRepository> logger)
        {
            _connectionString = configuration.GetConnectionString("LiquidLabsConnectionString");
            _logger = logger;
        }


        public async Task<User?> GetByIdAsync(int id)
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                await connection.OpenAsync();

                var query = @"SELECT Id, Name, Username, Email, Phone, Website, 
                             Street, Suite, City, Zipcode, Latitude, Longitude,
                             CompanyName, CatchPhrase, BS
                             FROM Users 
                             WHERE Id = @Id";

                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                using var reader = await command.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    return reader.ToUser();
                }

                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error fetching user data for ID: {id}");
                throw;
            }
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                await connection.OpenAsync();

                var query = @"SELECT Id, Name, Username, Email, Phone, Website, 
                             Street, Suite, City, Zipcode, Latitude, Longitude,
                             CompanyName, CatchPhrase, BS
                             FROM Users 
                             WHERE Username = @Username";

                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);

                using var reader = await command.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    return reader.ToUser();
                }

                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error fetching user data for username: {username}");
                throw;
            }
        }

        public async Task<List<User>> GetAllAsync()
        {
            var users = new List<User>();

            try
            {
                using var connection = new SqlConnection(_connectionString);
                await connection.OpenAsync();

                var query = @"SELECT Id, Name, Username, Email, Phone, Website, 
                             Street, Suite, City, Zipcode, Latitude, Longitude,
                             CompanyName, CatchPhrase, BS
                             FROM Users 
                             ORDER BY Id";

                using var command = new SqlCommand(query, connection);
                using var reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    users.Add(reader.ToUser());
                }

                return users;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching all user data");
                throw;
            }
        }

        public async Task<User> InsertAsync(User user)
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                await connection.OpenAsync();

                var query = @"INSERT INTO Users 
                             (Id, Name, Username, Email, Phone, Website, 
                              Street, Suite, City, Zipcode, Latitude, Longitude,
                              CompanyName, CatchPhrase, BS)
                             VALUES 
                             (@Id, @Name, @Username, @Email, @Phone, @Website,
                              @Street, @Suite, @City, @Zipcode, @Latitude, @Longitude,
                              @CompanyName, @CatchPhrase, @BS)";

                using var command = new SqlCommand(query, connection);
                command.AddUserParameters(user);

                await command.ExecuteNonQueryAsync();

                _logger.LogInformation("Inserted user data for ID: {Id}, Username: {Username}",
                    user.Id, user.Username);

                return user;
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
            {
                _logger.LogWarning("User with ID {Id} already exists. Updating instead.", user.Id);
                return await UpdateAsync(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error inserting user data for ID: {Id}", user.Id);
                throw;
            }
        }

        public async Task<User> UpdateAsync(User user)
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                await connection.OpenAsync();

                var query = @"UPDATE Users 
                             SET Name = @Name, 
                                 Email = @Email, 
                                 Phone = @Phone, 
                                 Website = @Website,
                                 Street = @Street,
                                 Suite = @Suite,
                                 City = @City,
                                 Zipcode = @Zipcode,
                                 Latitude = @Latitude,
                                 Longitude = @Longitude,
                                 CompanyName = @CompanyName,
                                 CatchPhrase = @CatchPhrase,
                                 BS = @BS,
                             WHERE Id = @Id";

                using var command = new SqlCommand(query, connection);
                command.AddUserParameters(user);

                var rowsAffected = await command.ExecuteNonQueryAsync();

                if (rowsAffected == 0)
                {
                    throw new InvalidOperationException($"User with ID {user.Id} not found for update");
                }

                _logger.LogInformation("Updated user data for ID: {Id}", user.Id);

                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating user data for ID: {Id}", user.Id);
                throw;
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                await connection.OpenAsync();

                var query = "SELECT COUNT(1) FROM Users WHERE Id = @Id";

                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                var count = (int)await command.ExecuteScalarAsync();
                return count > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error checking if user exists for ID: {Id}", id);
                throw;
            }
        }

    }
}
