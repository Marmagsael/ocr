﻿using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace LibraryMySql;

public class MySqlDataAccess : IMySqlDataAccess
{
    private readonly IConfiguration _config;

    public MySqlDataAccess(IConfiguration config)
    {
        _config = config;
    }

    public async Task<List<T>> FetchData<T, U>(string sql, U parameters, string connName = "MySqlConn")
    {
        string connString = _config.GetConnectionString(connName);
        using (IDbConnection conn = new MySqlConnection(connString))
        {
            var list = await conn.QueryAsync<T>(sql, parameters);
            return list.ToList();
        }
    }

    public Task ExecuteCmd<T>(string sql, T parameters, string connName = "MySqlConn")
    {
        string connString = _config.GetConnectionString(connName); 
        using (IDbConnection conn = new MySqlConnection(connString))
        {
            return conn.ExecuteAsync(sql, parameters);
        }
    }

    public IDbConnection GetConnString(string connName = "MySqlConn")
    {
        string connString = _config.GetConnectionString(connName); 
        return new MySqlConnection(connString); 
    }
}
