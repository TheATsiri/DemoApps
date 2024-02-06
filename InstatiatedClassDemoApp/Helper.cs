using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstatiatedClassDemoApp
{
    public static class Helper
    {
        public static List<PersonModel> SeedData()
        {
            List<PersonModel> output = new List<PersonModel>();
            string firstName = string.Empty;

            do
            {
                Console.Write("Entre person's first name:");
                firstName = Console.ReadLine();
                Console.Write("Entre person's last name:");
                string lasttName = Console.ReadLine();
                if (firstName.ToLower() != "exit")
                {
                    PersonModel person = new PersonModel()
                    {
                        FirstName = firstName,
                        LastName = lasttName
                    };
                    output.Add(person);
                }

            } while (firstName.ToLower() != "exit");

            return output;
        }

        public static void ShowData(List<PersonModel> listOfPeople)
        {
            foreach (var person in listOfPeople)
            {
                Console.WriteLine($"{person.FirstName} - {person.LastName} ");
            }
        }
    }
}
