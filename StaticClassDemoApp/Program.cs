using StaticClassDemoApp.Models;

namespace StaticClassDemoApp
{
    internal class Program
    {
        static List<PersonModel> partyList = new();
        static void Main(string[] args)
        {
            var partyList = Helper.SeedPartyList();

            Helper.ShowPartyList(partyList);

            Console.ReadLine();
        }
    }
}
