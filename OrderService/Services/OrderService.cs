using Grpc.Core;
using OrderService;
using OrderService.Data;
using Service;

namespace OrderService.Services
{
    public class OrderService : Order.OrderBase
    {
        private readonly ILogger<OrderService> _logger;

        private readonly List<Service.Product> _avaliableProducts;
        public OrderService(ILogger<OrderService> logger)
        {
            _logger = logger;
            _avaliableProducts = Products.GetProducts();
        }

        public override Task<ProductListResponse> GetProducts(ProductRequest request, ServerCallContext context)
        {
            // Create a ProductListResponse and set the products property
            var response = new ProductListResponse
            {
                ProductList = { _avaliableProducts }
            };

            return Task.FromResult(response);
        }

        public override Task<BillingReply> Checkout(BillingRequest request, ServerCallContext context)
        {
            var findProduct = _avaliableProducts.Find(x => x.Id == int.Parse(request.ProductId));
            var total = findProduct!.Price * (int.Parse(request.Quantity));

            return Task.FromResult(new BillingReply
            {
                Message = "Hello " + request.Name + ", you ordered "+request.Quantity+" of "+findProduct.Name,
                Total = total.ToString()
            });
        }
    }
}