using System.ComponentModel.DataAnnotations;

namespace ASPNETLabCourse.Models
{
    public class Shoes
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public TargetGender TargetGender { get; set; }
        public decimal Price { get; set; }
        public ushort AvailableQuantity { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
