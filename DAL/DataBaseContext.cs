
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace DAL
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<User>  Users { get; set; }

         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-62N3GQT\MSSQLSERVER2019 ; Initial Catalog=Ef_ValueConversions; integrated security=true");
         }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var enumToString = new ValueConverter<OrderStatus,string>(p => p.ToString(), p => (OrderStatus)Enum.Parse(typeof(OrderStatus), p));

            //modelBuilder.Entity<Order>()
            //      .Property(p => p.OrderStatus)
            //      .HasConversion(p => p.ToString(), p => (OrderStatus)Enum.Parse(typeof(OrderStatus), p));

            modelBuilder.Entity<Order>()
                .Property(p => p.OrderStatus)
                .HasConversion(enumToString);

            var boolToString = new BoolToStringConverter("No","Yes");

            modelBuilder.Entity<Order>()
                .Property(p => p.Done)
                .HasConversion(boolToString);


            modelBuilder.Entity<User>()
                .Property(p => p.Email)
                .HasConversion(p => Base64Encode(p), p => Base64Decode(p));
            

        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
 
 
}
