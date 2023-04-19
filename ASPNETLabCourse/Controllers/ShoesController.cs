using ASPNETLabCourse.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETLabCourse.Controllers
{
    public class ShoesController : Controller
    {
        private readonly IAllShoes _allShoes;
        private readonly IShoesCategory _shoesCategory;

        public ShoesController(IAllShoes allShoes, IShoesCategory shoesCategory)
        {
            _allShoes = allShoes;
            _shoesCategory = shoesCategory;
        }

        public ViewResult List()
        {
            return View(_allShoes.GetShoes);
        }
    }
}
