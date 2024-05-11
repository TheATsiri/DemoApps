
namespace DataAccess.DBAccess;

public interface ISqlDataAccess
{
    Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionId = "Default");
    Task SaveData<U>(string storedProcedure, U parameters, string connectionId = "Default");
}