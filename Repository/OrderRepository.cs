using YumBlazor.Data;
using YumBlazor.Repository.IRepository;

namespace YumBlazor.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public Task<OrderHeader> CreateAsync(OrderHeader orderheader)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderHeader>> GetAllAsync(string? userid = null)
        {
            throw new NotImplementedException();
        }

        public Task<OrderHeader> GetAsync(int orderId)
        {
            throw new NotImplementedException();
        }

        public Task<OrderHeader> UpdateStatusAsync(int orderId, string status)
        {
            throw new NotImplementedException();
        }
    }
}
