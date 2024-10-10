// See https://aka.ms/new-console-template for more information
using Exceptional;

Console.WriteLine("Hello, World!");

var person = new Person("John", "Doe");

var fname = "Jane";
string lname = null;

//try
//{
//    var person2 = new Person(fname, lname);
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.GetType().FullName);
//    Console.WriteLine(ex.Message);
//}

//try
//{
//    var person2 = new Person(fname, lname);
//}
//catch (ArgumentNullException ex)
//{
//    Console.WriteLine(ex.GetType().FullName);
//    Console.WriteLine(ex.Message);
//}

//Console.WriteLine("End of the program");

if (fname == null)
{
    Console.WriteLine("First name is null");
    fname = "---";
}

if (lname == null)
{
    Console.WriteLine("Last name is null");
    throw new LastNameException();
}

var person2 = new Person(fname, lname);
