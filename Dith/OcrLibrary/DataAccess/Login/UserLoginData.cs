using Dapper;

namespace OcrLibrary.DataAccess.Login;

public class UserLoginData
{
    private readonly ISqlDataAccess _dataAccess;

    public UserLoginData(ISqlDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }

    public record UserData(
        int Id,
        string UserName,
        string Email,
        string Domain,
        string RememberToken);

    public async Task<UserData?> LoginAttempt(string email, string password)
    {
        var parameter = new DynamicParameters();
        parameter.Add("@email", email, System.Data.DbType.String);
        parameter.Add("@password", password, System.Data.DbType.AnsiString);
        var cmd = "select [Id], [UserName], [Email], Domain, RememberToken from [dbo].[Users] where Email = @email and [Password] = HASHBYTES('SHA2_512', @password) ";
        var results = await _dataAccess.FetchCmdQS<UserData, dynamic>(cmd, parameter, "Default");
        return results.FirstOrDefault();

    }
}

