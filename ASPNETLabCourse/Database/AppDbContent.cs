﻿using ASPNETLabCourse.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNETLabCourse.Database
{
    public class AppDbContent : DbContext
    {
        public AppDbContent (DbContextOptions<AppDbContent> options): base(options) { }
        public DbSet<Shoes> Shoes { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ShopCartItem> ShopCartItem { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }

    }
}
