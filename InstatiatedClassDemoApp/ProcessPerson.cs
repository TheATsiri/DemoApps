using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstatiatedClassDemoApp
{
    public static class ProcessPerson
    {
        public static void GreetingPerson(PersonModel person)
        {
            Console.WriteLine($"{person.FirstName} - {person.LastName} ");
            person.HasBeenGreeted = true;
        }
    }
}
