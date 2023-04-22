using ASPNETLabCourse.Interfaces;
using ASPNETLabCourse.Models;
using System.Collections.Generic;

namespace ASPNETLabCourse.Mocks
{
    public class MockShoes : IAllShoes
    {
        private readonly IShoesCategory _shoesCategory = new MockCategory();
        private List<Shoes> _shoes;

        public MockShoes()
        {
            _shoes = new List<Shoes>()
                {
                    new Shoes{Id = 1, Name = "Nike Air Monarch IV", Size = 40,
                    Description = "Чоловічі кросівки Nike Air Monarch IV – повна підтримка для комфортного руху.\n" +
                    "Модель із верхом із міцної шкіри для підтримки підготує вас до тренувань. " +
                    "Легкий піноматеріал та амортизуюча вставка Nike Air забезпечують комфорт при кожному кроці.",
                    ImageUrl = "https://content2.rozetka.com.ua/goods/images/big/310826910.jpg",
                    TargetGender = TargetGender.Male, Price = 3769, AvailableQuantity = 15, Category = _shoesCategory.GetCategory(1)},
                    new Shoes{Id = 2, Name = "Жіночі челсі низькі MELLY Lizzy", Size = 37,
                    Description = "Челсі у класичному стилі на масивній підошві.",
                    ImageUrl = "https://content2.rozetka.com.ua/goods/images/big/309083198.jpg",
                    TargetGender= TargetGender.Female, Price = 2419, AvailableQuantity = 10, Category = _shoesCategory.GetCategory(2)},
                    new Shoes{Id = 3, Name = "Туфлі Bastion", Size = 41,
                    Description = "Матеріал верху: натуральна шкіра; Матеріал підкладки: натуральна шкіра;\n" +
                    "Матеріал устілки: текстиль; Матеріал підошви: гума.",
                    ImageUrl = "https://content1.rozetka.com.ua/goods/images/big/143903424.jpg",
                    TargetGender = TargetGender.Male, Price = 2650, AvailableQuantity = 20, Category = _shoesCategory.GetCategory(3)}
                };
        }

        public IEnumerable<Shoes> GetShoes 
        {
            get {
                return _shoes;
            }
        }

        public Shoes GetShoesById(int Id)
        {
            return _shoes.Find(x => x.Id == Id);
        }

        public IEnumerable<Shoes> GetShoesByCategory(string Category)
        {
            return _shoes.FindAll(x => x.Category.Name.Equals(Category));
        }
    }
}
