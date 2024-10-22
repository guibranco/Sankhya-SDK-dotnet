using System.Threading.Tasks;

namespace Sankhya.IntegrationTests
{
    public interface IOrderRepository
    {
        Task<Order> GetOrderAsync(string orderId);
    }
}
