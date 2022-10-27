namespace OcrLibrary.DataAccess
{
    public interface ISqlDataAccess
    {
        Task ExecuteCmdQS<T>(string cmd, T parameters, string connectionStringName = "Default");
        Task ExecuteCmdSP<T>(string storedProcedure, T parameters, string connectionStringName = "Default");
        Task<List<T>> FetchCmdQS<T, U>(string cmd, U parameters, string connectionStringName = "Default");
        Task<List<T>> FetchCmdSP<T, U>(string storedProcedure, U parameters, string connectionStringName = "Default");
    }
}