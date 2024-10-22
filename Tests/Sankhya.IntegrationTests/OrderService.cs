using System.Threading.Tasks;

namespace Sankhya.IntegrationTests
{
    public class OrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Task<Order> GetOrderAsync(string orderId) => _orderRepository.GetOrderAsync(orderId);
    }
}
