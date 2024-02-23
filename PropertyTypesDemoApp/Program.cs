namespace PropertyTypesDemoApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PersonModel person = new();

            person.FirstName = "Antonios";
            person.LastName = "Tsiriplis";
            person.Age = 30;
            person.SSN = "123-45-5678";

            Console.WriteLine($"Person's info: {person.FirstName} - {person.LastName}, age of {person.Age} and SSN:{person.SSN}");


            AddressModel address = new AddressModel("Kalvou 1", "Athens", "Attica", "146-71");

            Console.WriteLine($"The person {person.FullName} lives in {address.FullAddress}");


            Console.ReadLine();
        }
    }
}
