using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace OcrLibrary.DataAccess;

public class SqlDataAccess : ISqlDataAccess
{
    private readonly IConfiguration _config;

    public SqlDataAccess(IConfiguration config)
    {
        _config = config;
    }


    public async Task<List<T>> FetchCmdSP<T, U>(string storedProcedure, U parameters, string connectionStringName = "Default")
    {
        string connectionString = _config.GetConnectionString(connectionStringName);
        using IDbConnection connection = new SqlConnection(connectionString);
        var rows = await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);

        return rows.ToList();
    }

    public async Task ExecuteCmdSP<T>(string storedProcedure, T parameters, string connectionStringName = "Default")
    {
        string connectionString = _config.GetConnectionString(connectionStringName);
        using IDbConnection connection = new SqlConnection(connectionString);
        await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task<List<T>> FetchCmdQS<T, U>(string cmd, U parameters, string connectionStringName = "Default")
    {
        string connectionString = _config.GetConnectionString(connectionStringName);
        using IDbConnection connection = new SqlConnection(connectionString);
        var rows = await connection.QueryAsync<T>(cmd, parameters, commandType: CommandType.Text);

        return rows.ToList();
    }

    public async Task ExecuteCmdQS<T>(string cmd, T parameters, string connectionStringName = "Default")
    {
        string connectionString = _config.GetConnectionString(connectionStringName);
        using IDbConnection connection = new SqlConnection(connectionString);
        await connection.ExecuteAsync(cmd, parameters, commandType: CommandType.Text);
    }


}

