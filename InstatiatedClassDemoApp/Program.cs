namespace InstatiatedClassDemoApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var people = Helper.SeedData();
            Helper.ShowData(people);

            Console.ReadLine();
        }
    }
}
