using ASPNETLabCourse.Database;
using ASPNETLabCourse.Interfaces;
using ASPNETLabCourse.Models;
using System.Collections.Generic;
using System.Linq;

namespace ASPNETLabCourse.Repositories
{
    public class CategoryRepository : IShoesCategory
    {
        private readonly AppDbContent appDbContent;

        public CategoryRepository(AppDbContent appDbContent) { this.appDbContent = appDbContent; }

        public IEnumerable<Category> AllCategories => appDbContent.Category;

        public Category GetCategory(int Id) => appDbContent.Category.FirstOrDefault(c => c.Id == Id);
    }
}