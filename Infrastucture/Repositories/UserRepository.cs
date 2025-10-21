using Application;
using Application.Interfaces.Repositories;
using Dapper;
using Domain;

// ReSharper disable once CheckNamespace
namespace Infrastructure;

public class UserRepository : IUserRepository
{
    private readonly IConnectionFactory _connectionFactory;
    
    public UserRepository(IConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<IEnumerable<UserEntity?>> GetAllUsersAsync(CancellationToken cancellationToken = default)
    {
        using var connection = _connectionFactory.CreateConnection();
        connection.Open();
        
        const string sql = """
                               SELECT user_id, name, age, phone, email, username, role
                               FROM users
                           """;
        
        var command = new CommandDefinition(sql, cancellationToken: cancellationToken);
        return await connection.QueryAsync<UserEntity>(command);
    }

    public async Task<UserEntity?> GetUserByIdAsync(int id, CancellationToken cancellationToken)
    {
        using var connection = _connectionFactory.CreateConnection();
        connection.Open();
        
        const string sql = """
                               SELECT user_id, name, age, phone, email, username, role
                               FROM users WHERE user_id = @id
                           """;
        var command = new CommandDefinition(sql, new {id}, cancellationToken: cancellationToken);
        return await connection.QueryFirstOrDefaultAsync<UserEntity>(command);

    }

    public async Task<int> UpdateUserAsync(int id, UserEntity user,  CancellationToken cancellationToken)
    {
        using var connection = _connectionFactory.CreateConnection();
        connection.Open();
        
        const string sql = "UPDATE users SET name = @Name, age = @Age, phone = @Phone, email = @Email " +
                           "WHERE user_id = @Id";
        
        var command = new CommandDefinition(sql, new
        {
            Id = id,
            user.Name,
            user.Age,
            user.Phone,
            user.Email
        }, cancellationToken: cancellationToken);
        
        return await connection.ExecuteAsync(command);
    }

    public async Task<int> DeleteUserAsync(int id,  CancellationToken cancellationToken)
    {
        using var connection = _connectionFactory.CreateConnection();
        connection.Open();
        var sql = "DELETE FROM users WHERE user_id = @id";
        var command = new CommandDefinition(sql, new {id}, cancellationToken: cancellationToken);
        return await connection.ExecuteAsync(command);
    }
    
}