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

            //ReadAllContacts(sql);     // Read all Contacts

            //ReadContact(sql, 13);      // Read one Contact

            //CreateNewContact(sql);

            //UpdateContact(sql);

            //RemovePhoneNumberFromContact(sql, 1, 1);

            Console.WriteLine("Done Processing!");

            Console.ReadLine();
        }
        private static void RemovePhoneNumberFromContact(SqlCrud sql, int contactId, int PhoneNumberId)
        {
            sql.RemovePhoneNumberFromContact(contactId, PhoneNumberId);
        }
        private static void UpdateContact(SqlCrud sql)
        {
            BasicContactModel contact = new BasicContactModel
            {
                Id = 1,
                FirstName = "Antonios",
                LastName = "Tsiriplis"
            };
            sql.UpdateContactName(contact);
        }
        private static void CreateNewContact(SqlCrud sql)
        {
            FullContactModel user = new FullContactModel
            {
                BasicInfo = new BasicContactModel { FirstName = "Kostas", LastName = "Tsiriplis" }
            };

            user.EmailAddresses.Add(new EmailAddressModel { EmailAddress = "nope@nope.com" });
            user.EmailAddresses.Add(new EmailAddressModel { Id = 1, EmailAddress = "at@at.com" });

            user.PhoneNumbers.Add(new PhoneNumberModel { Id = 1, PhoneNumber = "555-1212" });
            user.PhoneNumbers.Add(new PhoneNumberModel { PhoneNumber = "555-7777" });

            sql.CreateContact(user);
        }
        private static void ReadAllContacts(SqlCrud sql)
        {
            var rows = sql.GetAllContacts();
            foreach (var row in rows)
            {
                Console.WriteLine($"{row.Id}: {row.FirstName} and  {row.LastName} ");
            }
        }
        private static void ReadContact(SqlCrud sql, int contactId)
        {
            var contact = sql.GetFullContact(contactId);

            Console.WriteLine($"{contact.BasicInfo.Id}: {contact.BasicInfo.FirstName} and  {contact.BasicInfo.LastName} ");

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
