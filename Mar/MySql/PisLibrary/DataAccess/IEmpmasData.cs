using PisLibrary.Models;

namespace PisLibrary.DataAccess
{
    public interface IEmpmasData
    {
        Task<List<EmployeeInfoModel?>> GetEmployeeList();
    }
}