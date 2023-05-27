using ASPNETLabCourse.Interfaces;
using ASPNETLabCourse.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETLabCourse.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrder _orders;
        private readonly ShopCart _shopCart;

        public OrderController(IOrder orders, ShopCart shopCart)
        {
            _orders = orders;
            _shopCart = shopCart;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            _shopCart.ShopCartItems = _shopCart.GetShopCartItems();
            if (_shopCart.ShopCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Для початку необхідно додати взуття у кошик!");
            }
            if (ModelState.IsValid)
            {
                _orders.createOrder(order);
                return RedirectToAction("Complete");
            }
            return View(order);
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Замовлення успішно створено!";
            return View();
        }
    }
}
