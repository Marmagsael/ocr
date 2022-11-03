using Dapper;
using OcrLibrary.Models.Menus;
using System.Data.SqlClient;
using System.Data;

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
