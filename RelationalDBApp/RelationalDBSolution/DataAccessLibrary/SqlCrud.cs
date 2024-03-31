using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class SqlCrud
    {
        private readonly string _connectionString;
        private SQLDataAccess db = new SQLDataAccess();

        public SqlCrud(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<BasicContactModel> GetAllContacts()
        {
            string sql = "Select Id,FirstName,LastName from dbo.Contacts";

            return db.LoadData<BasicContactModel, dynamic>(sql, new { }, _connectionString);

        }
        public FullContactModel GetFullContact(int id)
        {
            string sql = "Select Id,FirstName,LastName from dbo.Contacts where Id=@Id";

            FullContactModel output = new();

            output.BasicInfo = db.LoadData<BasicContactModel, dynamic>(sql, new { Id = id }, _connectionString).FirstOrDefault();

            if (output.BasicInfo == null)
            {
                // TODO: tell the user the the record was not found
                //throw new Exception("User not found!");
                return null;
            }
            sql = "select e.*\r\nfrom dbo.EmailAdrdresses e\r\ninner join dbo.ContactEmail ce on ce.EmailAddressId=e.Id\r\nwhere ce.ContactId=@Id";

            output.EmailAddresses = db.LoadData<EmailAddressModel, dynamic>(sql, new { Id = id }, _connectionString);

            sql = "select p.*\r\nfrom dbo.PhoneNumbers p\r\ninner join dbo.ContactPhoneNumbers cp on cp.PhoneNumberId=p.Id\r\nwhere cp.ContactId=@Id";

            output.PhoneNumbers = db.LoadData<PhoneNumberModel, dynamic>(sql, new { Id = id }, _connectionString);


            return output;
        }

        public void CreateContact(FullContactModel contact)
        {
            // Save the basic contact
            string sql = "insert into dbo.Contacts (FirstName,LastName) values (@FirstName,@LastName)";
            db.SaveData(sql,
                        new { contact.BasicInfo.FirstName, contact.BasicInfo.LastName, },
                        _connectionString);

            // Get the ID number of the created basic contact
            sql = "select Id form dbo.Contacts where FirstName=@FirstName and LastName=@LastName;";
            int contactId = db.LoadData<IdLookUpModel, dynamic>(sql,
                                                              new { contact.BasicInfo.FirstName, contact.BasicInfo.LastName },
                                                              _connectionString).First().Id;

            foreach (var phoneNumber in contact.PhoneNumbers)
            {
                if (phoneNumber.Id == 0)
                {
                    sql = "insert into dbo.PhoneNumbers (PhoneNumber) values (@PhoneNumber)";
                    db.SaveData(sql, new { phoneNumber.PhoneNumber }, _connectionString);

                    phoneNumber.Id = db.LoadData<IdLookUpModel, dynamic>(sql,
                                                                      new { phoneNumber.PhoneNumber },
                                                                      _connectionString).First().Id;

                }

                sql = "insert into dbo.ContactPhoneNumbers (ContactId,PhoneNumberId) values (@ContactId,@PhoneNumberId)";
                db.SaveData(sql,
                            new { ContactId = contactId, PhoneNumberId = phoneNumber.Id },
                            _connectionString);

            }
            foreach (var email in contact.EmailAddresses)
            {
                if (email.Id == 0)
                {
                    sql = "insert into dbo.EmailAddresses (EmailAddress) values (@EmailAddress)";
                    db.SaveData(sql, new { email.EmailAddress }, _connectionString);

                    email.Id = db.LoadData<IdLookUpModel, dynamic>(sql,
                                                                   new { email.EmailAddress },
                                                                   _connectionString).First().Id;
                }


            }


        }
    }
}
