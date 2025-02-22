using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace YumBlazor.Data
{
    public class Product
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(0.01, 1000)]
        public decimal Price { get; set; }

        public string? Description { get; set; }
        public string? SpecialTag { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }


        //Images are saved in wwwroot/images/product folder.The ImageUrl property will store the
        //path to the image file. The question mark (?) after the string type indicates that the
        //property can be null. This is useful when creating a new product that does not have an
        //image yet.The ImageUrl property will be null until an image is uploaded.
        public string? ImageUrl { get; set; }



    }
}
