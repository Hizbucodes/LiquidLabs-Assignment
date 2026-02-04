using LiquidLabs.Models.Entities;
using Microsoft.Data.SqlClient;

namespace LiquidLabs.Extensions
{
    public static class SqlCommandExtensions
    {
        public static void AddUserParameters(this SqlCommand command, User user)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            if (user == null)
                throw new ArgumentNullException(nameof(user));

            command.Parameters.AddWithValue("@Id", user.Id);
            command.Parameters.AddWithValue("@Name", user.Name);
            command.Parameters.AddWithValue("@Username", user.Username);
            command.Parameters.AddWithValue("@Email", user.Email);
            command.Parameters.AddWithValue("@Phone", user.Phone ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Website", user.Website ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Street", user.Street ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Suite", user.Suite ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@City", user.City ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Zipcode", user.Zipcode ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Latitude", user.Latitude ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Longitude", user.Longitude ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@CompanyName", user.CompanyName ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@CatchPhrase", user.CatchPhrase ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BS", user.BS ?? (object)DBNull.Value);
        }
    }
}
