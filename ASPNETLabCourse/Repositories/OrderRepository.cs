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
            appDbContent.OrderDetail.AddRange(shopCart.ShopCartItems
                .Select(shoes => new OrderDetail
                {
                    OrderId = order.Id,
                    ShoesId = shoes.Id,
                    Price = shoes.Price,
                    Quantity = shoes.Quantity,
                }));
            appDbContent.SaveChanges();
        }

    }
}