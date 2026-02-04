namespace LiquidLabs.Models.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public string? Website { get; set; }
        public string? Street { get; set; }
        public string? Suite { get; set; }
        public string? City { get; set; }
        public string? Zipcode { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        public string? CompanyName { get; set; }
        public string? CatchPhrase { get; set; }
        public string? BS { get; set; }
    }
}
