using Newtonsoft.Json;

namespace LiquidLabs.Models.DTOs.JsonPlaceholder
{
    public class CompanyDto
    {
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("catchPhrase")]
        public string CatchPhrase { get; set; } = string.Empty;

        [JsonProperty("bs")]
        public string BS { get; set; } = string.Empty;
    }
}
