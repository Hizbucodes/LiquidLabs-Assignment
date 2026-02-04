using Newtonsoft.Json;

namespace LiquidLabs.Models.DTOs.JsonPlaceholder
{
    public class GeoDto
    {
        [JsonProperty("lat")]
        public string Latitude { get; set; } = string.Empty;

        [JsonProperty("lng")]
        public string Longitude { get; set; } = string.Empty;
    }
}
