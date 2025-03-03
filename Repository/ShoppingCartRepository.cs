using Microsoft.Identity.Client; 
using Microsoft.EntityFrameworkCore;
using YumBlazor.Data;
using YumBlazor.Repository.IRepository;

namespace YumBlazor.Repository
{
    //Implement IShoppingCartRepository
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly ApplicationDbContext _db;
        //Constructor
        public ShoppingCartRepository(ApplicationDbContext db) 
        {
            _db = db;
        }

        //Implement the methods from the interface
        public async Task<bool> ClearCartAsync(string? userId)
        {
            var cartItems = await _db.ShoppingCart.Where(u => u.UserID == userId).ToListAsync();
            _db.ShoppingCart.RemoveRange(cartItems);
            return await _db.SaveChangesAsync() > 0;
        }
        public async Task<IEnumerable<ShoppingCart>> GetAllAsync(string? userId)
        {
            return await _db.ShoppingCart.Where(u => u.UserID == userId).Include(u => u.Product).ToListAsync();
        }

        public async Task<int> GetTotalCartCartCountAsync(string? userId)
        {
            int cartCount = 0;
            var cartItems = await _db.ShoppingCart.Where(u => u.UserID == userId).ToListAsync();
            foreach(var item in cartItems)
            {
                cartCount += item.Count;
            }
            return cartCount;
        }

        public async Task<bool> UpdateCartAsync(string userId, int productId, int updateBy)
        {
            if(string.IsNullOrEmpty(userId))
            {
                return false;
            }
            var cart = await _db.ShoppingCart.FirstOrDefaultAsync(u => u.UserID == userId && u.ProductID == productId);
            if(cart == null)
            {
                cart = new ShoppingCart
                {
                    UserID = userId,
                    ProductID = productId,
                    Count = updateBy
                };
                //When adding a new record to a shopping cart, we need to add it to the database async
                await _db.ShoppingCart.AddAsync(cart);

            }
            //If the cart is not null, update the count of the item(s) in the cart
            else
            {
                cart.Count += updateBy;
         
            if (cart.Count <= 0 )
                {
                    //I know that I do not have to say it is .ShoppingCart, but I am doing it for clarity
                    _db.ShoppingCart.Remove(cart);
                }
            }
            //Save the changes to the database but pay attention to the return type and location of the await keyword
            return await _db.SaveChangesAsync() > 0;
        }
    
    }
}
