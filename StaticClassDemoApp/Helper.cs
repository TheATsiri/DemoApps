using StaticClassDemoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticClassDemoApp
{
    public class Helper
    {
        public static List<PersonModel> SeedPartyList()
        {
            List<PersonModel> output = new();

            CreatePartyList(output);


            return output;
        }

        public static void ShowPartyList(List<PersonModel> partyList)
        {
            foreach (var person in partyList)
            {
                Console.WriteLine($"{person.FirstName} - {person.LastName} , is active:{person.IsActive}");
            }
        }

        private static void CreatePartyList(List<PersonModel> partyList)
        {
            string firstName = string.Empty;
            do
            {
                Console.Write("Enter your first name or type 'exit' to close the application:");
                firstName = Console.ReadLine();
                if (!string.IsNullOrEmpty(firstName))
                {
                    Console.Write("Enter your last name:");
                    string lastName = Console.ReadLine();
                    if (!string.IsNullOrEmpty(lastName))
                    {
                        bool isActive = true;
                        partyList.Add(new PersonModel { FirstName = firstName, LastName = lastName, IsActive = isActive });
                    }
                }

            } while (firstName.ToLower() != "exit");

        }
    }
}
