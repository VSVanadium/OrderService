The solution contains two solutions
1. OrderService (gRPC service)
2. Consumer ( Console Application)

## OrderService

Open the Protos\order.proto file and define your service:
every new method you define here will be avaliable for implementation under your Service class

Implement the service logic:
Open the Services\OrderService.cs file and implement the endpoint defined in proto file.

Open proto file properties
Build action: Protobuf compiler
gRPC Stub class: server only

![Image Alt Text](/Images/2023-12-15%2013_33_14-.png)

## Consumer

Add in csproj file:
```
<ItemGroup>
    <PackageReference Include="Grpc.Net.Client" Version="2.41.0" />
    <PackageReference Include="Google.Protobuf" Version="3.18.0" />
    <PackageReference Include="Grpc.Tools" Version="2.41.0" />
</ItemGroup>
```
  
Add refernec to your server project  
  
Add proto file
in properties:
Build action: Protobuf compiler
gRPC Stub class: client only

Create Channel
using var channel = GrpcChannel.ForAddress("http://localhost:5039") #your uri to service, configure in appsettings

Create Client
var client = new Order.OrderClient(channel);

Call Method
var request = new BillingRequest { Name = name, Product = "Bread", Quantity = quantity };
var response = client.Checkout(request);

Now, Run both the projects and give inputs to the prompts on the console:

![Image Alt Text](/Images/2023-12-15%2013_42_08-Microsoft%20Visual%20Studio%20Debug%20Console.png)


