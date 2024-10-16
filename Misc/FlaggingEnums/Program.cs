// See https://aka.ms/new-console-template for more information
using FlaggingEnums;

Console.WriteLine("Hello, World!");

//var pizza = Pizza.MakePizza((PizzaToppings)(16 + 4));
var pizza1 = Pizza.MakePizza(PizzaToppings.Ham | PizzaToppings.Mushrooms);
var pizza2 = Pizza.MakePizza(PizzaToppings.Ham | PizzaToppings.Pepperoni);