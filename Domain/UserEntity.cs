namespace Domain;

public class UserEntity
{
    public int UserId { get; init; }
    public required string Username { get; init; }
    public required string Email { get; init; }
    public required string PasswordHash { get; set; }
    public required string Role { get; init; } = "User";

    public required string Name { get; init; }
    public int Age { get; init; }
    public required string Phone { get; init; }
}