namespace Domain;

public class AdminSettings
{
    public string Username { get; init; } = null!;
    public string Password { get; init; } = null!;
    public string Email { get; init; } = null!;
    public string Role { get; init; } = "Admin";
}