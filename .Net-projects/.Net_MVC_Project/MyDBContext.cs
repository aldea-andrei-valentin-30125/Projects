using System;
using MVCFinalProject.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
//using Microsoft.EntityFrameworkCore;


using System.ComponentModel.DataAnnotations;
//using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;


namespace MVCFinalProject
{
    public class MyDBContext : DbContext
    {
        public DbSet<Produs> Produse { get; set; }

        public DbSet<Cart> Cart { get; set; }
        
        public DbSet<OrderItem> OrderItem { get; set; }

        public DbSet<Restaurant> Restaurante { get; set; }

        public DbSet<Client> Clienti { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Delivery> Deliveries { get; set; }

        public DbSet<FavoriteRestaurant> FavoriteRestaurants { get; set; }

        public MyDBContext()
            : base("name=DefaultConnection")
        {

        }
    }
}