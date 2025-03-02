using System.ComponentModel.DataAnnotations;
namespace YumBlazor.Data
{
    public class OrderHeader
    {
        public int ID { get; set; }
        [Required]
        public string UserID { get; set; }

        [Required]
        [Display(Name = "Order Total")]
        public double OrderTotal { get; set; }

        [Required]
        public DateOnly OrderDate { get; set; }

        [Required]
        public string Status { get; set; }

        [Display(Name = "Name")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Phone Number")]
        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    }
}
