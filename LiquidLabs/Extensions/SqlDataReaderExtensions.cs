using LiquidLabs.Models.Entities;
using Microsoft.Data.SqlClient;

namespace LiquidLabs.Extensions
{
    public static class SqlDataReaderExtensions
    {
        public static User ToUser(this SqlDataReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            return new User
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                Name = reader.GetString(reader.GetOrdinal("Name")),
                Username = reader.GetString(reader.GetOrdinal("Username")),
                Email = reader.GetString(reader.GetOrdinal("Email")),
                Phone = reader.GetNullableString("Phone"),
                Website = reader.GetNullableString("Website"),
                Street = reader.GetNullableString("Street"),
                Suite = reader.GetNullableString("Suite"),
                City = reader.GetNullableString("City"),
                Zipcode = reader.GetNullableString("Zipcode"),
                Latitude = reader.GetNullableString("Latitude"),
                Longitude = reader.GetNullableString("Longitude"),
                CompanyName = reader.GetNullableString("CompanyName"),
                CatchPhrase = reader.GetNullableString("CatchPhrase"),
                BS = reader.GetNullableString("BS"),
            };
        }

        private static string? GetNullableString(this SqlDataReader reader, string columnName)
        {
            var ordinal = reader.GetOrdinal(columnName);
            return reader.IsDBNull(ordinal) ? null : reader.GetString(ordinal);
        }
    }
}
