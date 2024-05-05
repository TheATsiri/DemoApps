

using Microsoft.Extensions.Configuration;

namespace UploadFileLibrary;

public class SqlDataAccess
{
    private readonly IConfiguration _config;

    public SqlDataAccess(IConfiguration config)
    {
        _config = config;
    }

    public async Task SaveData(
        string storedProc,
        string connectionName,
        object parameters)
    {
        string connectionString = _config.GetConnectionString(connectionName);
    }
}
