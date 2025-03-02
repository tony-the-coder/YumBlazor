using System.ComponentModel.DataAnnotations.Schema;

namespace YumBlazor.Data
{
    public class ShoppingCart
    {

        public int ID { get; set; }
            //The  shopping cart needs to store things for a specific user
        public string UserID { get; set; }
        [ForeignKey("UserID")]

        //Retrieves the navigation property for the user
        public ApplicationUser User { get; set; }

        //The shopping cart will store a list of items that the user has added to the cart
        public int ProductID { get; set; }
        [ForeignKey("ProductID")]
        public Product Product { get; set; }

        public int Count { get; set; }



    }
}
