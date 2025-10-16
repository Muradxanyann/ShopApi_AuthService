namespace Shared.Dto.UserDto;

public class UserUpdateDto
{
    public required string Name { get; set; } 
    public int Age { get; set; }   
    public required string Phone { get; set; }
    public required string Email { get; set; }
}