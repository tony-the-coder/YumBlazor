using YumBlazor.Data;

namespace YumBlazor.Utility
//This is a static class that will hold all the static details
//of the application.For example, the roles of the users, the session keys, etc.
//This class will be used to avoid hardcoding the values in the application.
{
    public static class SD
    {
        public static string Role_Admin = "Admin";
        public static string Role_Customer = "Customer";

        public static string StatusPending = "Pending";
        public static string StatusReadyForPickup = "ReadyForPickup";
        public static string StatusCompleted = "Completed";
        public static string StatusCancelled = "Cancelled";

        public static List<OrderDetail> ConvertShoppingCartListToOrderDetails(List<ShoppingCart> shoppingCarts)
        {
            
            
                List<OrderDetail> orderDetails = new List<OrderDetail>();

                foreach(var cart in shoppingCarts)
                {
                    OrderDetail orderDetail = new OrderDetail
                    {
                        ProductId = cart.ProductID,
                        Count = cart.Count,
                        Price = Convert.ToDouble(cart.Product.Price),
                        ProductName = cart.Product.Name

                        
                    };
                    orderDetails.Add(orderDetail);
                }
                return orderDetails;
            }
           
        }

    }

