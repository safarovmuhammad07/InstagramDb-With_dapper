using System.Data.Common;
using Npgsql;

namespace Infrastructure.DataContext;

public class DapperContext:IDapperContext
{
    readonly string connectionString=  "Server=localhost; Port = 5432; Database = Examination; User Id = postgres; Password = 1234;";
    

    public DbConnection GetConnection()
    {
        return new NpgsqlConnection(connectionString);
    }
}

public interface IDapperContext
{
    public DbConnection GetConnection();
}