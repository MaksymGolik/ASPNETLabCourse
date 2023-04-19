using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASPNETLabCourse.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Shoes> Shoes { get; set; }
    }
}
