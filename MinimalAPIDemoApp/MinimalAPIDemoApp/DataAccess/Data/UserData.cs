using DataAccess.DBAccess;
using DataAccess.Models;

namespace DataAccess.Data;
public class UserData : IUserData
{
    private readonly ISqlDataAccess _db;
    public UserData(ISqlDataAccess db)
    {
        _db = db;
    }

    // Read Operation
    public Task<IEnumerable<UserModel>> GetUsers() => _db.LoadData<UserModel, dynamic>("dbo.spUser_GetAll", new { });

    // CRUD Operations

    // C - Create Operation
    public Task InsertUser(UserModel user) => _db.SaveData("dbo.spUser_Insert", new { user.FirstName, user.LaststName });
    // R - Read Operation by passing an id 
    public async Task<UserModel?> GetUser(int id)
    {
        var results = await _db.LoadData<UserModel, dynamic>("dbo.spUser_Get", new { Id = id });

        return results.FirstOrDefault();
    }
    // U - Update Operation
    public Task UpdateUser(UserModel user) => _db.SaveData("dbo.spUser_Update", user);
    // D- Delete operation
    public Task DeleteUser(int id) => _db.SaveData("dbo.spUser_Delete", new { Id = id });
}
