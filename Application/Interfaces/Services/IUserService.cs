using Domain;
using Shared.Dto.UserDto;

namespace Application.Interfaces.Services;

public interface IUserService
{
    Task<IEnumerable<UserResponseDto?>> GetAllUsersAsync(CancellationToken cancellationToken = default);
    Task<UserEntity?>  GetUserByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<int> UpdateUserAsync(int id, UserUpdateDto user, CancellationToken cancellationToken = default);
    Task<int> DeleteUserAsync(int id, CancellationToken cancellationToken = default);
}