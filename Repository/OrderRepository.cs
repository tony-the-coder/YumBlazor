using Microsoft.EntityFrameworkCore;
using YumBlazor.Data;
using YumBlazor.Repository.IRepository;

namespace YumBlazor.Repository { 
//{ @*Implementing the IOrderRepository interface and needs to be injected into Program.cs*@
    public class OrderRepository : IOrderRepository
    {
        //@*Injecting the ApplicationDbContext into the OrderRepository*@
        private readonly ApplicationDbContext _db;

        //@*Constructor*@

        public OrderRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<OrderHeader> CreateAsync(OrderHeader orderHeader)
        {
            // Set the order date to the current date and time, add the order to the database,
            // save changes, and return the created order.
            orderHeader.OrderDate = DateOnly.FromDateTime(DateTime.Now);
            await _db.OrderHeader.AddAsync(orderHeader);
            await _db.SaveChangesAsync();
            return orderHeader;
        }

        public async Task<IEnumerable<OrderHeader>> GetAllAsync(string? userid = null)
        {
            if (!string.IsNullOrEmpty(userid))
            {
                return await _db.OrderHeader.Where(u => u.UserID == userid).ToListAsync();
            }
            return await _db.OrderHeader.ToListAsync();
        }

        public async Task<OrderHeader> GetAsync(int id)
        //@*Obtain the order with the specified ID from the database and display*@
        {
            return await _db.OrderHeader.Include(u => u.OrderDetails).FirstOrDefaultAsync(u => u.ID == id);
        }

        public async Task<OrderHeader> UpdateStatusAsync(int orderId, string status)
        {
            var orderHeader = await _db.OrderHeader.FirstOrDefaultAsync(u => u.ID == orderId);
            if (orderHeader != null)
            {
                orderHeader.Status = status;
                await _db.SaveChangesAsync();
            }
            return orderHeader;
        }
    }
}
