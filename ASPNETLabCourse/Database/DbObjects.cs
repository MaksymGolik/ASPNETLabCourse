using ASPNETLabCourse.Models;
using System.Collections.Generic;
using System.Linq;

namespace ASPNETLabCourse.Database
{
    public class DbObjects
    {
        private static Dictionary<string, Category> _Category;
        private static Dictionary<string, Shoes> _Shoes;

        public static void Initial (AppDbContent appDbContent) 
        { 
            if(!appDbContent.Category.Any())
            {
                appDbContent.Category.AddRange(Categories.Select(c => c.Value));
            }
            if (!appDbContent.Shoes.Any()) 
            {
                appDbContent.Shoes.AddRange(Shoes.Select(s => s.Value));
            }
            appDbContent.SaveChanges();
        }

        public static Dictionary<string, Category> Categories
        {
            get { 
                if(_Category == null)
                {
                    var categories = new List<Category>
                    {
                        new Category { Name = "Кросівки",
                            Description = "Закрите взуття, зазвичай передбачає наявність шнурків, " +
                            "характерна товста підошва, яка добре згинається, для того, щоб зробити " +
                            "заняття спортом комфортнішими для ніг." },
                        new Category { Name = "Черевики",
                            Description = "Взуття, що закриває ногу по щиколотку, рідше до середини " +
                            "гомілки, зазвичай на шнурівці або застібках." },
                        new Category { Name = "Туфлі",
                            Description = "Легке чоловіче і жіноче взуття, що закриває ногу не вище щиколотки." }
                    };
                    _Category = new Dictionary<string, Category>();
                    categories.ForEach(c => _Category.Add(c.Name, c));
                }
                return _Category;
            }
        }

        public static Dictionary<string, Shoes> Shoes 
        { 
            get { 
                if(_Shoes == null)
                {
                    var shoes = new List<Shoes>()
                    {
                        new Shoes{Id = 1, Name = "Nike Air Monarch IV", Size = 40,
                        Description = "Чоловічі кросівки Nike Air Monarch IV – повна підтримка для комфортного руху.\n" +
                        "Модель із верхом із міцної шкіри для підтримки підготує вас до тренувань. " +
                        "Легкий піноматеріал та амортизуюча вставка Nike Air забезпечують комфорт при кожному кроці.",
                        ImageUrl = "https://content2.rozetka.com.ua/goods/images/big/310826910.jpg",
                        TargetGender = TargetGender.Male, Price = 3769, AvailableQuantity = 15, Category = Categories["Кросівки"]},
                        new Shoes{Id = 2, Name = "Жіночі челсі низькі MELLY Lizzy", Size = 37,
                        Description = "Челсі у класичному стилі на масивній підошві.",
                        ImageUrl = "https://content2.rozetka.com.ua/goods/images/big/309083198.jpg",
                        TargetGender= TargetGender.Female, Price = 2419, AvailableQuantity = 10, Category = Categories["Черевики"]},
                        new Shoes{Id = 3, Name = "Туфлі Bastion", Size = 41,
                        Description = "Матеріал верху: натуральна шкіра; Матеріал підкладки: натуральна шкіра;\n" +
                        "Матеріал устілки: текстиль; Матеріал підошви: гума.",
                        ImageUrl = "https://content1.rozetka.com.ua/goods/images/big/143903424.jpg",
                        TargetGender = TargetGender.Male, Price = 2650, AvailableQuantity = 20, Category = Categories["Туфлі"]}
                    };
                    _Shoes = new Dictionary<string, Shoes>();
                    shoes.ForEach(s => _Shoes.Add(s.Name, s));
                }
                return _Shoes;
            } 
        }
    }
}