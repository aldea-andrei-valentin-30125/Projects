using System;
using MVCFinalProject.Models;
using MVCFinalProject.Controllers;
using MVCFinalProject.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Microsoft.AspNet.Identity;
using EnumStatus = MVCFinalProject.Models.EnumStatus;


namespace MVCFinalProject.Controllers
{
    public class ClientController : Controller
    {

        private readonly MyDBContext _context;

        public ClientController()
        {
            _context = new MyDBContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }
        // GET: Client


        [Authorize(Roles = "Client")]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            Client clienti = _context.Clienti.Where(x => x.UserId == userId).FirstOrDefault();
            if (clienti == null)
            {
                return View("NewClient");
            }
            else
            {
                var restaurantes = _context.Restaurante.ToList();

                var ViewModel = new RestauranteClientViewModel
                {
                    Clienti = clienti,
                    Restaurante = restaurantes,
                };

                return View(ViewModel);
            }
        }

        [Authorize(Roles = "Client")]
        public ActionResult ViewProducts(int id)
        {
            Restaurant restaurant = _context.Restaurante.Where(x => x.Id == id).FirstOrDefault();


                var produse = _context.Produse.Where(x => x.RestaurantId == restaurant.Id).ToList();

                var ViewModel = new RandomRestaurantViewModels
                {
                    Restaurant = restaurant,
                    Produse = produse
                };

                return View(ViewModel);
            
        }
        [Authorize(Roles = "Client")]
        public ActionResult AddToCart(int id)
        {
            var userId = User.Identity.GetUserId();
            Client client = _context.Clienti.Where(x => x.UserId == userId).FirstOrDefault();
            Cart cart = _context.Cart.Where(x => x.CliendId == client.Id).FirstOrDefault();


            if (id != 0)
            {
                var produs = _context.Produse.Where(x => x.Id == id).FirstOrDefault();
                _context.OrderItem.Add(new OrderItem { CartId = cart.Id, ProductId = id });
                _context.SaveChanges();
            }

            List<OrderItem> orderItems = new List<OrderItem>();
            orderItems = _context.OrderItem.Where(x => x.CartId == cart.Id).ToList();

            List<Produs> produse = new List<Produs>();

            foreach(var item in orderItems)
            {
                produse.Add( _context.Produse.Where(x => x.Id == item.ProductId).FirstOrDefault());
            }
            

            var ViewModel = new CartViewModel
            {
                Clienti = client,
                Produse = produse
            };

            return View(ViewModel);

        }

        [Authorize(Roles = "Client")]
        [HttpPost]
        public ActionResult Create(Client client)
        {
            _context.Clienti.Add(new Client { Name = client.Name, UserId = User.Identity.GetUserId(), Adresa = client.Adresa});
            _context.SaveChanges();

            var userId = User.Identity.GetUserId();
            Client clientAfterRegister = _context.Clienti.Where(x => x.UserId == userId).FirstOrDefault();
            _context.Cart.Add(new Cart { CliendId = clientAfterRegister.Id });
            _context.SaveChanges();

            return RedirectToAction("Index");

        }

        [Authorize(Roles = "Client")]
        public ActionResult SendCommand()
        {           
            var userId = User.Identity.GetUserId();
            Client client = _context.Clienti.Where(x => x.UserId == userId).FirstOrDefault();
            Cart cart = _context.Cart.Where(x => x.CliendId == client.Id).FirstOrDefault();

            _context.Orders.Add(new Order { CartId = cart.Id, CliendId = client.Id ,CreatedAt = DateTime.Now, Status = EnumStatus.Trimis});
            _context.SaveChanges();

            _context.Cart.Remove(cart);
            _context.SaveChanges();

            _context.Cart.Add(new Cart {CliendId = client.Id });
            _context.SaveChanges();


            return RedirectToAction("Index");
        }
        
        public ActionResult Search(string searchName)
        {

            if (!String.IsNullOrEmpty(searchName) )
            {
                var projects = _context.Restaurante.Where(c => c.Name.Contains(searchName)).FirstOrDefault();
                if(projects != null) 
                { 
                    return RedirectToAction("ViewProducts", new { id = projects.Id });
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        

        [Authorize(Roles = "Client")]
        public ActionResult AddToFavorite(int id)
        {
            var userId = User.Identity.GetUserId();
            Client clienti = _context.Clienti.Where(x => x.UserId == userId).FirstOrDefault();
            var number = _context.FavoriteRestaurants.Where(x => x.RestaurantId == id && x.CliendId == clienti.Id).Count();
            if(number == 0)
            {         
                _context.FavoriteRestaurants.Add(new FavoriteRestaurant { CliendId = clienti.Id, RestaurantId = id });
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult ViewFavorite()
        {
            var userId = User.Identity.GetUserId();
            Client clienti = _context.Clienti.Where(x => x.UserId == userId).FirstOrDefault();

            var favoriteRestaurantes = _context.FavoriteRestaurants.Where(x => x.CliendId == clienti.Id).ToList();
            if (favoriteRestaurantes != null)
            {
                List<Restaurant> restaurants = new List<Restaurant>();
                foreach (var item in favoriteRestaurantes)
                {
                    restaurants.Add(_context.Restaurante.Where(x => x.Id == item.RestaurantId).FirstOrDefault());
                }
                var ViewModel = new RestauranteClientViewModel
                {
                    Clienti = clienti,
                    Restaurante = restaurants,
                };

                return View(ViewModel);
            }
            else { return RedirectToAction("Index"); }


        }

        public ActionResult DeleteFavorite(int id)
        {

            FavoriteRestaurant favorite = _context.FavoriteRestaurants.Where(x => x.RestaurantId == id).FirstOrDefault();

            if(favorite != null) { 
                _context.FavoriteRestaurants.Remove(favorite);
                _context.SaveChanges();
            }
           
            return RedirectToAction("ViewFavorite");
        }
    }
}