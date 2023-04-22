using ASPNETLabCourse.Interfaces;
using ASPNETLabCourse.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETLabCourse.Controllers
{
    [Route("Shoes")]
    public class ShoesController : Controller
    {
        private readonly IAllShoes _allShoes;
        private readonly IShoesCategory _shoesCategory;

        public ShoesController(IAllShoes allShoes, IShoesCategory shoesCategory)
        {
            _allShoes = allShoes;
            _shoesCategory = shoesCategory;
        }

        [HttpGet("List")]
        public ViewResult List(string category)
        {
            if (!string.IsNullOrEmpty(category))
            {
                return View(new ShoesListViewModel()
                {
                    allShoes = _allShoes.GetShoesByCategory(category),
                    currentCategory = category
                }) ;
            }
            return View(new ShoesListViewModel()
            {
                allShoes = _allShoes.GetShoes,
                currentCategory = "Все взуття"
            }) ;
        }
    }
}
