// See https://aka.ms/new-console-template for more information

using BuildingStrings;
using Bogus;
using System.Diagnostics;

Faker<LocalPerson> faker = new Faker<LocalPerson>()
    .RuleFor(p => p.FirstName, f => f.Name.FirstName())
    .RuleFor(p => p.LastName, f => f.Name.LastName())
    .RuleFor(p => p.Age, f => f.Random.Int(18, 65));

var people = faker.Generate(2_000_000);


StringGenerator generator = new GeneratorBuilder();

Stopwatch sw = Stopwatch.StartNew();
var result = generator.Concatenate(people);
sw.Stop();

Console.WriteLine($"Elapsed time: {sw.ElapsedMilliseconds} ms");
Console.WriteLine($"Total length: {result.Length} chars");




