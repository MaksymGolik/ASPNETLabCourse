using ASPNETLabCourse.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ASPNETLabCourse.Models
{
    public class ShopCart
    {
        private readonly AppDbContent AppDbContent;

        public ShopCart(AppDbContent AppDbContent)
        {
            this.AppDbContent = AppDbContent;
        }

        public string ShopCartId { get; set; }
        public List<ShopCartItem> ShopCartItems { get; set; }

        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDbContent>();
            string ShopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", ShopCartId);
            return new ShopCart(context) { ShopCartId = ShopCartId };
        }

        public void AddToCart(Shoes Shoes, int Quantity)
        {
            AppDbContent.ShopCartItem.Add(new ShopCartItem
            {
                ShopCartId = ShopCartId,
                Shoes = Shoes,
                Price = Shoes.Price * Quantity,
                Quantity = Quantity
            });
            AppDbContent.SaveChanges();
        }

        public List<ShopCartItem> GetShopCartItems()
        {
            return AppDbContent.ShopCartItem.Where(c => c.ShopCartId == ShopCartId).Include(s => s.Shoes).ToList();
        }

    }
}
