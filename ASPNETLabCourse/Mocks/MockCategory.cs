using ASPNETLabCourse.Interfaces;
using ASPNETLabCourse.Models;
using System.Collections.Generic;

namespace ASPNETLabCourse.Mocks
{
    public class MockCategory : IShoesCategory
    {
        private List<Category> _categories;

        public MockCategory()
        {
            _categories = _categories = new List<Category>
            {
                new Category { Id = 1, Name = "Кросівки",
                    Description = "Закрите взуття, зазвичай передбачає наявність шнурків, " +
                        "характерна товста підошва, яка добре згинається, для того, щоб зробити " +
                        "заняття спортом комфортнішими для ніг." },
                new Category { Id = 2, Name = "Черевики",
                    Description = "Взуття, що закриває ногу по щиколотку, рідше до середини " +
                        "гомілки, зазвичай на шнурівці або застібках." },
                new Category { Id = 3, Name = "Туфлі",
                    Description = "Легке чоловіче і жіноче взуття, що закриває ногу не вище щиколотки." }
            };
        }

        public IEnumerable<Category> AllCategories 
        { 
            get {
                return _categories;
            }
        }

        public Category GetCategory(int Id)
        {
            return _categories.Find(c => c.Id == Id);
        }
    }
}
