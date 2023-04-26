using ASPNETLabCourse.Interfaces;
using ASPNETLabCourse.ViewModels;
using ASPNETLabCourse.Models;
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
            ViewBag.Title = "Сторінка з взуттям";
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

        [HttpGet("{id}")]
        public IActionResult Shoes(int id)
        {
            Shoes shoes = _allShoes.GetShoesById(id);
            if(shoes == null)
            {
                return NotFound("Shoes with id: " + id + " not found.");
            }
            ViewBag.Title = shoes.Name;
            return View(shoes);
        }
    }
}
