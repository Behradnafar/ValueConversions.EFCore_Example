using DAL;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using static DAL.DataBaseContext;

namespace Ui
{
    class Program
    {
        static void Main(string[] args)
        {
            DataBaseContext context = new DataBaseContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            Order order = new Order()
            {
                OrderStatus = OrderStatus.Delivered, 
                Done=true,
            };
            context.Orders.Add(order);
            context.SaveChanges();


            var _order = context.Orders.FirstOrDefault();


            User user = new User()
            {
                Email = "info@bugeto.net"
            };
            context.Add(user);
            context.SaveChanges();


            var _user = context.Users.FirstOrDefault();

            Console.WriteLine("Hello World!");
        }
    }
}
