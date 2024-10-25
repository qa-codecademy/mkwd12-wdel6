// See https://aka.ms/new-console-template for more information
using ApiProcessor;

Console.WriteLine("Hello, Server World!");

var server = new ServerTwo.Core.Server();

server.RegisterService<ICalculatorService, CalculatorService>();

server.RegisterProcessor(new AddPipelineProcessor());
server.RegisterController<CalculatorController>();


server.RegisterStaticRoot("public");

server.Start();

