using Newtonsoft.Json;

namespace LiquidLabs.Models.DTOs.JsonPlaceholder
{
    public class AddressDto
    {
        [JsonProperty("street")]
        public string Street { get; set; } = string.Empty;

        [JsonProperty("suite")]
        public string Suite { get; set; } = string.Empty;

        [JsonProperty("city")]
        public string City { get; set; } = string.Empty;

        [JsonProperty("zipcode")]
        public string Zipcode { get; set; } = string.Empty;

        [JsonProperty("geo")]
        public GeoDto Geo { get; set; } = new GeoDto();
    }
}
