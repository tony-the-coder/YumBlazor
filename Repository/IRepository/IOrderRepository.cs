using YumBlazor.Data;

namespace YumBlazor.Repository.IRepository
{
    public interface IOrderRepository
    {

        public Task<OrderHeader> CreateAsync(OrderHeader orderheader);
        public Task<OrderHeader> GetAsync(int orderId);
        public Task<IEnumerable<OrderHeader>> GetAllAsync(string? userid=null);
        public Task<OrderHeader> UpdateStatusAsync(int orderId, string status);
    }
}
