using System.ComponentModel.DataAnnotations;
namespace YumBlazor.Data
{
    public class OrderDetail
    {

        public int Id { get; set; }
        public int OrderHeaderId { get; set; }
        public OrderHeader OrderHeader { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Required]
        public int Count { get; set; }
        [Required]
        public double Price { get; set; }

        //We will add this property to store the product name
        //in the order detail because it might change. Do not delete products.
        //Disable it to keep data integrity
        [Required]
        public string ProductName { get; set; }
    }
}
