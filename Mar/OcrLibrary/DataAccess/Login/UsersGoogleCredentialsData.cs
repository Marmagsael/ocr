using Dapper;
using OcrLibrary.DataAccess;
using OcrLibrary.Models.Login;
using System.Xml.Linq;

namespace OcrLibrary.DataAccess.Login;

public class UsersGoogleCredentialsData
{
    private readonly ISqlDataAccess _sql;

    public UsersGoogleCredentialsData(ISqlDataAccess sql)
    {
        _sql = sql;
    }

    public async Task<UsersGoogleCredentialsModel?> GetUserByIdQS(int id)
    {
        var cmd = "select * from [dbo].[UsersGoogleCredentials] where Id = @Id ";
        var results = await _sql.FetchCmdQS<UsersGoogleCredentialsModel, dynamic>(cmd, new { Id = id }, "Default");
        return results.FirstOrDefault();
    }
    public async Task<UsersGoogleCredentialsModel?> GetUserByNameidentifierQS(string nameIdentifier)
    {
        var cmd = "select * from [dbo].[UsersGoogleCredentials] where NameIdentifier = @nameIdentifier ";
        var results = await _sql.FetchCmdQS<UsersGoogleCredentialsModel, dynamic>(cmd, new { NameIdentifier = nameIdentifier }, "Default");
        return results.FirstOrDefault();
    }

    public async Task InsertUserQS(UsersGoogleCredentialsModel user)
    {
        var cmd = @"Insert into [dbo].[UserGoogleCredentials] (Id,  NameIdentifier,  Name,  GivenName,  SurName,  Email,  PictureAddress) 
                                                       values (@Id, @NameIdentifier, @Name, @GivenName, @SurName, @Email, @PictureAddress)";
        await _sql.ExecuteCmdQS(cmd, new
        {
            user.Id,
            user.NameIdentifier,
            user.Name,
            GivenName = user.GiveName,
            user.SurName,
            user.Email,
            user.PictureAddress
        });
    }


    public async Task UpdateUserQS(UsersGoogleCredentialsModel user)
    {
        var cmd = @"Update [dbo].[UserGoogleCredentials] set 
                            NameIdentifier  = @NameIdentifier, 
                            Name            = @Name,
                            GivenName       = @GiveName,
                            SurName         = @SurName,
                            Email           = @Email,
                            PictureAddress  = @PictureAddress 
                    where   Id              = @Id ";

        await _sql.ExecuteCmdQS(cmd,
                    new
                    {
                        user.Id,
                        user.NameIdentifier,
                        user.Name,
                        GivenName = user.GiveName,
                        user.SurName,
                        user.Email,
                        user.PictureAddress
                    });
    }
    public async Task UpdateUserByNameIdentifierQS(UsersGoogleCredentialsModel user)
    {
        var cmd = @"Update [dbo].[UserGoogleCredentials] set 
                            Id              = @Id, 
                            Name            = @Name,
                            GivenName       = @GiveName,
                            SurName         = @SurName,
                            Email           = @Email,
                            PictureAddress  = @PictureAddress 
                    where   NameIdentifier  = @NameIdentifier ";

        await _sql.ExecuteCmdQS(cmd,
                    new
                    {
                        user.Id,
                        user.NameIdentifier,
                        user.Name,
                        GivenName = user.GiveName,
                        user.SurName,
                        user.Email,
                        user.PictureAddress
                    });
    }

    public async Task DeleteUserQS(int id)
    {
        var cmd = @"Update from [dbo].[UserGoogleCredentials] where Id = @Id ";
        await _sql.ExecuteCmdQS(cmd, new { Id = id });
    }

    public async Task DeleteUserByNameIdentifierQS(string nameIdentifier)
    {
        var cmd = @"Update from [dbo].[UserGoogleCredentials] where NameIdentifier = @NameIdentifier ";
        await _sql.ExecuteCmdQS(cmd, new { NameIdentifier = nameIdentifier });
    }
}
