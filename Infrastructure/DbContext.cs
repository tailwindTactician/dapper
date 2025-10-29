using Npgsql;
namespace Infrastructure;

public class DbContext
{
    private readonly string _connectionString = "Host=localhost;Port=5432;Database=Engineers;Username=postgres;Password=1234";

    public NpgsqlConnection GetConnection()
    {
        return new NpgsqlConnection(_connectionString);
    }
}
