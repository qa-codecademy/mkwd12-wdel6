// See https://aka.ms/new-console-template for more information
using Staticing;

Console.WriteLine("Hello, World!");

var generator = new ItemGenerator();
var item = generator.GenerateItem(SysConfiguration.DateProvider);

var user = new ItemUser();
user.UseItem(item);
user.UseItem(item);


///-------///-------

StateStatic.Prepare("State Static Changed");
//....
StateStatic.Run();