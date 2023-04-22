using System.Collections.Generic;
using ASPNETLabCourse.Models;

namespace ASPNETLabCourse.ViewModels
{
    public class ShoesListViewModel
    {
        public IEnumerable<Shoes> allShoes { get; set; }
        public string currentCategory { get; set; }
    }
}
