using System.Data;

namespace Application;

public interface IConnectionFactory
{
    IDbConnection CreateConnection();
}