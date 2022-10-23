
using Dapper;
using OcrLibrary.Models;

namespace OcrLibrary.DataAccess;

public class UsersData : IUsersData
{
    private readonly ISqlDataAccess _sql;

    public UsersData(ISqlDataAccess sql)
    {
        _sql = sql;
    }

    public Task<List<UsersModel>> GetUsers()
    {
        return _sql.FetchCmdSP<UsersModel, dynamic>("dbo.spUsersGet", new { }, "Default");
    }

    public async Task<UsersModel?> GetUser(int id)
    {
        var results = await _sql.FetchCmdSP<UsersModel, dynamic>("dbo.spUsers_GetById", new { Id = id }, "Default");
        return results.FirstOrDefault();
    }

    public async Task<UsersModel?> GetUserQS(int id)
    {
        var cmd = "select * from [dbo].[Users] where Id = @id ";
        var results = await _sql.FetchCmdQS<UsersModel, dynamic>(cmd, new { Id = id }, "Default");
        return results.FirstOrDefault();
    }

    public async Task<UsersModel?> GetUserByEmailQS(string email, string password)
    {
        var parameter = new DynamicParameters();
        parameter.Add("@email", email, System.Data.DbType.String);
        parameter.Add("@password", password, System.Data.DbType.AnsiString);
        var cmd = "select * from [dbo].[Users] where Email = @email and [Password] = HASHBYTES('SHA2_512', @password) ";
        var results = await _sql.FetchCmdQS<UsersModel, dynamic>(cmd, parameter, "Default");
        return results.FirstOrDefault();
    }


    public async Task<UsersModel?> LoginByEmailQS(string email, string password)
    {
        var parameter = new DynamicParameters();
        parameter.Add("@email", email, System.Data.DbType.String);
        parameter.Add("@password", password, System.Data.DbType.AnsiString);
        var cmd = "select * from [dbo].[Users] where Email = @email and [Password] = HASHBYTES('SHA2_512', @password) ";
        var results = await _sql.FetchCmdQS<UsersModel, dynamic>(cmd, parameter, "Default");
        return results.FirstOrDefault();
    }

    public async Task<UsersModel?> FetchUserByEmailQS(string email)
    {
        var parameter = new DynamicParameters();
        parameter.Add("@email", email, System.Data.DbType.String);
        var cmd = "select * from [dbo].[Users] where Email = @email";
        var results = await _sql.FetchCmdQS<UsersModel, dynamic>(cmd, parameter, "Default");
        return results.FirstOrDefault();
    }

    public async Task CreateUserLogin(UsersModel usersModel)
    {
        var parameter = new DynamicParameters();
        parameter.Add("@email", usersModel.Email, System.Data.DbType.String);
        var sql = "insert into [dbo].[Users] (Email) values (@email)";
        await _sql.ExecuteCmdQS(sql, parameter, "Default");
    }

    public async Task CreateUserRegister(UsersModel usersModel)
    {
        var parameter = new DynamicParameters();
        parameter.Add("@userName", usersModel.UserName, System.Data.DbType.String);
        parameter.Add("@email", usersModel.Email, System.Data.DbType.String);
        parameter.Add("@password", usersModel.Password, System.Data.DbType.AnsiString);
        parameter.Add("@emailVerifiedAt", usersModel.EmailVerifiedAt, System.Data.DbType.String);
        parameter.Add("@domain", usersModel.Domain, System.Data.DbType.String);
        parameter.Add("@rememberToken", usersModel.RememberToken, System.Data.DbType.String);
        parameter.Add("@created", usersModel.Created, System.Data.DbType.DateTime);
        parameter.Add("@idUserCompany", usersModel.IdUserCompany, System.Data.DbType.String);

        var sql = "insert into [dbo].[Users] (UserName, Email, Password, EmailVerifiedAt, Domain, RememberToken, Created, IdUserCompany) " +
            "values (@userName, @email, HASHBYTES('SHA2_512', @password), @emailVerifiedAt, @domain, @rememberToken, @created, @idUserCompany )";
        await _sql.ExecuteCmdQS(sql, parameter, "Default");
    }












}
