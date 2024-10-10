// See https://aka.ms/new-console-template for more information
using ApiProcessor;

Console.WriteLine("Hello, Server World!");

var server = new ServerTwo.Core.Server();

server.RegisterProcessor(new AddPipelineProcessor());

server.Start();

