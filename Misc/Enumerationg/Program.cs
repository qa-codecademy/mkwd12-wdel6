// See https://aka.ms/new-console-template for more information
using Enumerationg;

Console.WriteLine("Hello, World!");

//var y = new MyEnumerable(1, 10);
//foreach (var x in y)
//{
//    Console.WriteLine(x);
//}

var evens1 = Numerics.Evens(1, 1_000_000).Take(3);
Console.WriteLine(Numerics.Counter);
foreach (var even in evens1)
{
    Console.WriteLine($"  {even}");
}

var evens2 = Numerics.YieldEvens(1, 1_000_000).Take(3);
foreach (var even in evens2)
{
    Console.WriteLine($"  {even}");
}

Console.WriteLine(Numerics.Counter);

var evens3 = Numerics.YieldEvens2(1, 100);
foreach (var even in evens3)
{
    Console.WriteLine($"  {even}");
}

Console.WriteLine(Numerics.Counter);