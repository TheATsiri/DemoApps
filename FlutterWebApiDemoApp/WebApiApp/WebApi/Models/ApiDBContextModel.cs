using Microsoft.EntityFrameworkCore;

namespace WebApi.Models
{
    public class ApiDBContextModel:DbContext
    {
        public ApiDBContextModel(DbContextOptions options):base(options) 
        {
            
        }


        public DbSet<UserModel> Users { get; set; }
    }
}
