using Newtonsoft.Json;

namespace LiquidLabs.Models.DTOs.JsonPlaceholder
{
    public class UserDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("username")]
        public string Username { get; set; } = string.Empty;

        [JsonProperty("email")]
        public string Email { get; set; } = string.Empty;

        [JsonProperty("phone")]
        public string Phone { get; set; } = string.Empty;

        [JsonProperty("website")]
        public string Website { get; set; } = string.Empty;

        [JsonProperty("address")]
        public AddressDto Address { get; set; } = new AddressDto();

        [JsonProperty("company")]
        public CompanyDto Company { get; set; } = new CompanyDto();
    }
}
