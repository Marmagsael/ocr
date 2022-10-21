using OcrLibrary.Models;

namespace OcrLibrary.DataAccess
{
    public interface IUsersData
    {
        Task CreateUserLogin(UsersModel usersModel);
        Task CreateUserRegister(UsersModel usersModel);
        Task<UsersModel?> FetchUserByEmailQS(string email);
        Task<UsersModel?> GetUser(int id);
        Task<UsersModel?> GetUserByEmailQS(string email, string password);
        Task<UsersModel?> GetUserQS(int id);
        Task<List<UsersModel>> GetUsers();
        Task<UsersModel?> LoginByEmailQS(string email, string password);
    }
}