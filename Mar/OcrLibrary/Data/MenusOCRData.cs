using Dapper;
using OcrLibrary.DataAccess;
using OcrLibrary.Models.Menus;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Mvc;

namespace OcrLibrary.Data;
public static class MenusOCRData
{

    public static async Task<List<MenusOcrModel?>> GetMenusOcr(string conn)
    {

        using IDbConnection connection = new SqlConnection(conn);
        string sql = "select * from MenuOCR order by odr, id ";
        var rows = await connection.QueryAsync<MenusOcrModel?>(sql, new { }, commandType: CommandType.Text);

        return rows.ToList();
    }

    
}
