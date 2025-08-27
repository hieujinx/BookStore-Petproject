using BookStore.Domain.Entities;
using BookStore.Application.DTOs.Users;

namespace BookStore.Application.Mappers.Users
{
    public static class UserMapper
    {
        // Entity → DTO (trả ra ngoài)
        public static UserDto ToDto(User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Role = user.Role,
                Phone = user.Phone,
                Address = user.Address,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt,
                IsActive = user.IsActive
            };
        }

        // DTO → Entity (khi tạo mới user)
        public static User ToEntity(CreateUserDto dto, string passwordHash)
        {
            return new User
            {
                Name = dto.Name.Trim(),
                Email = dto.Email.Trim().ToLower(),
                PasswordHash = passwordHash,
                Role = "User",
                Phone = dto.Phone,
                Address = dto.Address,
                CreatedAt = DateTime.UtcNow,
                IsActive = true
            };
        }

        // Cập nhật entity từ UpdateUserDto
        public static void UpdateEntity(User user, UpdateUserDto dto)
        {
            user.Name = dto.Name.Trim();
            user.Phone = dto.Phone;
            user.Address = dto.Address;
            user.UpdatedAt = DateTime.UtcNow;
        }
    }
}
