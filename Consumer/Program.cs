// See https://aka.ms/new-console-template for more information
using Grpc.Net.Client;
using Service;

Console.WriteLine("Hello, World!");
using var channel = GrpcChannel.ForAddress("http://localhost:5039");
var client = new Order.OrderClient(channel);

Console.WriteLine(("Enter your name:"));
var name = Console.ReadLine();

Console.WriteLine(("Enter product quantity:"));
var quantity = Console.ReadLine();

var request = new BillingRequest { Name = name, Product = "Bread", Quantity = quantity };

var response = client.Checkout(request);

Console.WriteLine($"Result: {response}");