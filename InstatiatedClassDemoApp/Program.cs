namespace InstatiatedClassDemoApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var people = Helper.SeedData();
            foreach (var person in people)
            {
                Console.WriteLine(person.FirstName);
            }

            Console.ReadLine();
        }
    }
}
