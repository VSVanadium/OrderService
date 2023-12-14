// See https://aka.ms/new-console-template for more information
using Grpc.Net.Client;
using Service;

Console.WriteLine("Hello, World!");
using var channel = GrpcChannel.ForAddress("http://localhost:5039");
var client = new Order.OrderClient(channel);

Console.WriteLine(("product List:"));
var productResponse = client.GetProducts(new ProductRequest { });

List<Product> productList = productResponse.ProductList.ToList();

foreach (var product in productList)
{
    Console.WriteLine(product.Id+" "+product.Name+":"+ product.Price+"$");
}

Console.WriteLine("");
Console.WriteLine("Enter your name");
var name = Console.ReadLine();

Console.WriteLine(("Enter id of product you want to buy:"));
var productId = Console.ReadLine();

Console.WriteLine(("Enter product quantity:"));
var quantity = Console.ReadLine();

var request = new BillingRequest { Name = name, ProductId = productId, Quantity = quantity };

var response = client.Checkout(request);

Console.WriteLine($"Result: {response}");