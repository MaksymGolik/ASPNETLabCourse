using ASPNETLabCourse.Models;
using System.Collections.Generic;

namespace ASPNETLabCourse.Interfaces
{
    public interface IShoesCategory
    {
        IEnumerable<Category> AllCategories { get; }
        Category GetCategory(int Id);
    }
}
