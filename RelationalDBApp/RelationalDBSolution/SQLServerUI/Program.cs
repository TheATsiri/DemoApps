using Microsoft.Extensions.Configuration;
using DataAccessLibrary;
using DataAccessLibrary.Models;

namespace SQLServerUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlCrud sql = new SqlCrud(GetConnectionString());

            ReadAllContacts(sql);

            Console.ReadLine();
        }
        private static void ReadAllContacts(SqlCrud sql)
        {
            var rows = sql.GetAllContacts();
            foreach (var row in rows)
            {
                Console.WriteLine($"{row.Id}: {row.FirstName} and  {row.LastName} ");
            }
        }
        private static string GetConnectionString(string connectionStringName = "Default")
        {
            string? output = "";

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var config = builder.Build();

            output = config.GetConnectionString(connectionStringName);

            return output;
        }
    }
}
