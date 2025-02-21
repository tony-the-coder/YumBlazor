using System.ComponentModel.DataAnnotations;

namespace YumBlazor.Data
{
    public class Category
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Category name is required")]
        public string Name { get; set; }
    }
}
