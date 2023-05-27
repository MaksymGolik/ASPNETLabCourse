using ASPNETLabCourse.Interfaces;
using ASPNETLabCourse.Models;
using ASPNETLabCourse.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ASPNETLabCourse.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly IAllShoes _shoesRepository;
        private readonly ShopCart _shopCart;

        public ShopCartController(IAllShoes shoesRepository, ShopCart shopCart)
        {
            _shoesRepository = shoesRepository;
            _shopCart = shopCart;
        }

        public ViewResult Index()
        {
            var items = _shopCart.GetShopCartItems();
            _shopCart.ShopCartItems = items;
            var shopCartViewModel = new ShopCartViewModel
            {
                shopCart = _shopCart
            };
            return View(shopCartViewModel);
        }

        public RedirectToActionResult AddToCart(int Id, int Quantity)
        {
            var item = _shoesRepository.GetShoesById(Id);
            if (item != null)
            {
                _shopCart.AddToCart(item, Quantity);
            }
            return RedirectToAction("Index");
        }
    }
}
