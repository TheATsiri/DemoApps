


List<int> numbers = [1, 2, 3];
List<string> strings = ["Antonios", "Tsiri", "Polo"];


TypeChecker(true);
TypeChecker(1);
TypeChecker("Antonios");
TypeChecker(new PersonRecord("antonios", "tsiriplis"));

void TypeChecker<T>(T value)
{
    Console.WriteLine($"Type : {typeof(T)}");
    Console.WriteLine($"Value : {value}");
}

record PersonRecord(string FirstName, string LastName);
