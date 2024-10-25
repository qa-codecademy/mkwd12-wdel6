// See https://aka.ms/new-console-template for more information
using Attributing;

var weko = new PersonBuilder()
    .WithFirstName("Weko slav")
    .WithLastName("Stefanovski")
    .WithAge(0x2F)
    .Build();

Console.WriteLine(weko);

