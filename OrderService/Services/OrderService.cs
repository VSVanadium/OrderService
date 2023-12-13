using Grpc.Core;
using OrderService;
using Service;

namespace OrderService.Services
{
    public class OrderService : Order.OrderBase
    {
        private readonly ILogger<OrderService> _logger;
        public OrderService(ILogger<OrderService> logger)
        {
            _logger = logger;
        }

        public override Task<BillingReply> Checkout(BillingRequest request, ServerCallContext context)
        {
            return Task.FromResult(new BillingReply
            {
                Message = "Hello " + request.Name,
                Total = ((int.Parse(request.Quantity) * 3.5)).ToString()
            });
        }
    }
}