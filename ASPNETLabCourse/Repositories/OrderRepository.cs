using ASPNETLabCourse.Database;
using ASPNETLabCourse.Interfaces;
using ASPNETLabCourse.Models;
using System;
using System.Linq;

namespace ASPNETLabCourse.Repositories
{
    public class OrderRepository : IOrder
    {
        private readonly AppDbContent appDbContent;
        private readonly ShopCart shopCart;

        public OrderRepository(AppDbContent appDbContent, ShopCart shopCart)
        {
            this.appDbContent = appDbContent;
            this.shopCart = shopCart;
        }

        public void createOrder(Order order)
        {
            order.OrderTime = DateTime.Now;
            order.OrderPrice = shopCart.GetShopCartItems().Sum(it => it.Price);
            appDbContent.Order.Add(order);
            appDbContent.SaveChanges();
            var items = shopCart.ShopCartItems;
            foreach (var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    ShoesId = el.Shoes.Id,
                    OrderId = order.Id,
                    Price = el.Price,
                    Quantity = el.Quantity
                };
                appDbContent.OrderDetail.Add(orderDetail);
            }

            appDbContent.SaveChanges();
        }

    }
}