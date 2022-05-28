using System;
using MVCFinalProject.Models;
using MVCFinalProject.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;




namespace MVCFinalProject.Controllers
{
    public class RestauranteController : Controller
    {
        
        private readonly MyDBContext _context;

        public RestauranteController()
        {
            _context = new MyDBContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }
        //Get:Customers
        [Authorize(Roles = "Restaurant")]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            Restaurant restaurant = _context.Restaurante.Where(x => x.UserId == userId).FirstOrDefault();

            if (restaurant == null)
            {
                return View("NewRestaurant");
            }
            else
            {

                var produse = _context.Produse.Where(x => x.RestaurantId == restaurant.Id).ToList();

                var ViewModel = new RandomRestaurantViewModels
                {
                    Restaurant = restaurant,
                    Produse = produse
                };

                return View(ViewModel);
            }
        }
        [Authorize(Roles = "Restaurant")]
        public ActionResult New()
        {
            return View("NewRestaurant");
        }
        [Authorize(Roles = "Restaurant")]
        public ActionResult NewProduct()
        {
            return View("newProduct");
        }

        [Authorize(Roles = "Restaurant")]
        [HttpPost]
        public ActionResult Create(Restaurant newRestaurant)
        {
            _context.Restaurante.Add(new Restaurant { Name = newRestaurant.Name, UserId = User.Identity.GetUserId() });
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Restaurant")]
        [HttpPost]
        public ActionResult CreateProduct(Produs newProduct)
        {

            var userId = User.Identity.GetUserId();
            Restaurant restaurant = _context.Restaurante.Where(x => x.UserId == userId).FirstOrDefault();

            newProduct.RestaurantId = restaurant.Id;
            _context.Produse.Add(newProduct);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        

        // GET: Customers/Delete/5
        [Authorize(Roles = "Restaurant")]
        public ActionResult DeleteProduct(int id)
        {

            Produs produs = _context.Produse.Where(x => x.Id == id).FirstOrDefault();
            Produs produsx = _context.Produse.Remove(produs);
            if (produsx == null)
            {
                return HttpNotFound();
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Customers/Delete/5
        [Authorize(Roles = "Restaurant")]
        public ActionResult EditProduct(int id)
        {

            Produs produs = _context.Produse.Where(x => x.Id == id).FirstOrDefault();

            var ViewModel = new EditProductViewModel
            {
                produs = produs,
            };

            return View(ViewModel);
        }

        [Authorize(Roles = "Restaurant")]
        public ActionResult SaveProduct(Produs produs)
        {
            var result = _context.Produse.Where(_o => _o.Id == produs.Id).FirstOrDefault();

            if (result != null)
            {
                result.Price = produs.Price;
                result.Name = produs.Name;
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

    }
}