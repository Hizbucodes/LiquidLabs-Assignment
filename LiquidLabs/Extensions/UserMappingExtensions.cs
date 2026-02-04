using LiquidLabs.Models.DTOs.JsonPlaceholder;
using LiquidLabs.Models.Entities;

namespace LiquidLabs.Extensions
{
    public static class UserMappingExtensions
    {
        public static User ToEntity(this UserDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            return new User
            {
                Id = dto.Id,
                Name = dto.Name,
                Username = dto.Username,
                Email = dto.Email,
                Phone = dto.Phone,
                Website = dto.Website,
                Street = dto.Address?.Street,
                Suite = dto.Address?.Suite,
                City = dto.Address?.City,
                Zipcode = dto.Address?.Zipcode,
                Latitude = dto.Address?.Geo?.Latitude,
                Longitude = dto.Address?.Geo?.Longitude,
                CompanyName = dto.Company?.Name,
                CatchPhrase = dto.Company?.CatchPhrase,
                BS = dto.Company?.BS,
            };
        }

        public static List<User> ToEntities(this IEnumerable<UserDto> dtos)
        {
            if (dtos == null)
                throw new ArgumentNullException(nameof(dtos));

            return dtos.Select(dto => dto.ToEntity()).ToList();
        }

        public static UserDto ToDto(this User entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            return new UserDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Username = entity.Username,
                Email = entity.Email,
                Phone = entity.Phone ?? string.Empty,
                Website = entity.Website ?? string.Empty,

                Address = new AddressDto
                {
                    Street = entity.Street ?? string.Empty,
                    Suite = entity.Suite ?? string.Empty,
                    City = entity.City ?? string.Empty,
                    Zipcode = entity.Zipcode ?? string.Empty,
                    Geo = new GeoDto
                    {
                        Latitude = entity.Latitude ?? string.Empty,
                        Longitude = entity.Longitude ?? string.Empty
                    }
                },

                Company = new CompanyDto
                {
                    Name = entity.CompanyName ?? string.Empty,
                    CatchPhrase = entity.CatchPhrase ?? string.Empty,
                    BS = entity.BS ?? string.Empty
                }
            };
        }
    }
}
