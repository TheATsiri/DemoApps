using DataAccessLibrary;
using DataAccessLibrary.Models;
using Microsoft.Extensions.Configuration;

namespace MySqlUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MySqlCrud sql = new MySqlCrud(GetConnectionString());

            //ReadAllContacts(sql);     // Read all Contacts

            ReadContact(sql, 2);      // Read one Contact

            //CreateNewContact(sql);

            //UpdateContact(sql);
            //ReadAllContacts(sql);

            //RemovePhoneNumberFromContact(sql, 1, 1);

            Console.WriteLine("Done Processing MySQL!");

            Console.ReadLine();
        }
        private static void RemovePhoneNumberFromContact(MySqlCrud sql, int contactId, int PhoneNumberId)
        {
            sql.RemovePhoneNumberFromContact(contactId, PhoneNumberId);
        }
        private static void UpdateContact(MySqlCrud sql)
        {
            BasicContactModel contact = new BasicContactModel
            {
                Id = 1,
                FirstName = "Ant",
                LastName = "Tsiriplis"
            };
            sql.UpdateContactName(contact);
        }
        private static void CreateNewContact(MySqlCrud sql)
        {
            FullContactModel user = new FullContactModel
            {
                BasicInfo = new BasicContactModel { FirstName = "Kostas", LastName = "Tsiriplis" }
            };

            user.EmailAddresses.Add(new EmailAddressModel { EmailAddress = "nope@nope.com" });
            user.EmailAddresses.Add(new EmailAddressModel { Id = 1, EmailAddress = "at@at.de" });

            user.PhoneNumbers.Add(new PhoneNumberModel { Id = 1, PhoneNumber = "555-1234" });
            user.PhoneNumbers.Add(new PhoneNumberModel { PhoneNumber = "555-7777" });

            sql.CreateContact(user);
        }
        private static void ReadAllContacts(MySqlCrud sql)
        {
            var rows = sql.GetAllContacts();
            foreach (var row in rows)
            {
                Console.WriteLine($"{row.Id}: {row.FirstName} -  {row.LastName} ");
            }
        }
        private static void ReadContact(MySqlCrud sql, int contactId)
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
