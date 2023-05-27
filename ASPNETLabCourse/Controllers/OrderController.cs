using ASPNETLabCourse.Interfaces;
using ASPNETLabCourse.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETLabCourse.Controllers
{
    [Route("Order")]
    public class OrderController : Controller
    {
        private readonly IOrder _orders;
        private readonly ShopCart _shopCart;

        public OrderController(IOrder orders, ShopCart shopCart)
        {
            _orders = orders;
            _shopCart = shopCart;
        }

        [HttpGet("Checkout")]
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost("Checkout")]
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
                return RedirectToAction("Complete", new { Id = order.Id });
            }
            return View(order);
        }

        [HttpGet("Complete")]
        public IActionResult Complete(int Id)
        {
            ViewBag.Message = "Замовлення успішно створено!";
            ViewBag.OrderId = Id;
            return View();
        }

        [HttpGet("{id}")]
        public IActionResult Show(int id)
        {
            Order order = _orders.GetOrderById(id);
            if (order == null)
            {
                return NotFound("Order with id: " + id + " not found.");
            }
            return View(order);
        }
    }
}