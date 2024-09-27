using Recording;

var wekoc1 = new PersonClass("Wekoslav", "Stefanovski", 0x2F);
var wekoc2 = new PersonClass("Wekoslav", "Stefanovski", 0x2F);

Console.WriteLine(wekoc1 == wekoc2); // False
Console.WriteLine(wekoc1.Equals(wekoc2)); // False
Console.WriteLine(ReferenceEquals(wekoc1, wekoc2)); // False
Console.WriteLine(wekoc1.FullName); // Wekoslav Stefanovski

var wekor1 = new PersonRecord("Wekoslav", "Stefanovski", 0x2F);
var wekor2 = new PersonRecord("Wekoslav", "Stefanovski", 0x2F);

Console.WriteLine(wekor1 == wekor2); // True
Console.WriteLine(wekor1.Equals(wekor2)); // True
Console.WriteLine(ReferenceEquals(wekor1, wekor2)); // False
Console.WriteLine(wekoc1.FullName); // Wekoslav Stefanovski

var wekos1 = new PersonStruct("Wekoslav", "Stefanovski", 0x2F);
var wekos2 = new PersonStruct("Wekoslav", "Stefanovski", 0x2F);

//Console.WriteLine(wekos1 == wekos2); // False
Console.WriteLine(wekos1.Equals(wekos2)); // False
Console.WriteLine(ReferenceEquals(wekos1, wekos2)); // False
Console.WriteLine(wekos1.FullName); // Wekoslav Stefanovski

var wekor1s = new PersonRecordStruct("Wekoslav", "Stefanovski", 0x2F);
var wekor2s = new PersonRecordStruct("Wekoslav", "Stefanovski", 0x2F);

Console.WriteLine(wekor1s == wekor2s); // True
Console.WriteLine(wekor1s.Equals(wekor2s)); // True
Console.WriteLine(ReferenceEquals(wekor1s, wekor2s)); // False

// Tupling

Func<string, (bool Success, int Value)> tryParse = (string input) =>
{
    if (int.TryParse(input, out var result))
    {
        return (true, result);
    }
    else
    {
        return (false, 0);
    }
};

var (success, value) = tryParse("42");

Console.WriteLine(success);
Console.WriteLine(value);

var tuple = tryParse("Wekoslav");

Console.WriteLine(tuple.Success); // False
Console.WriteLine(tuple.Value); // 0


if ((1, 2, 3, 4, 5) == (1, 2, 3, 9, 5))
{
    Console.WriteLine("Tuples are equal");
}
else
{
    Console.WriteLine("Tuples are not equal");
}

