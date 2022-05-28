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
    public class DeliveryController : Controller
    {
        // GET: Delivery
        private readonly MyDBContext _context;

        public DeliveryController()
        {
            _context = new MyDBContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }
        [Authorize(Roles = "Delivery")]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            Delivery delivery = _context.Deliveries.Where(x => x.UserId == userId).FirstOrDefault();
            if (delivery == null)
            {
                return View("NewDelivery");
            }
            else
            {
                var orders = _context.Orders.Where(o => o.Status == EnumStatus.Trimis).ToList();
                List<Client> clienti = new List<Client>();
                foreach (var order in orders)
                {
                    clienti.Add(_context.Clienti.Where(o => o.Id == order.Id).FirstOrDefault());
                }

                var ViewModel = new OrderDeliveryViewModel
                {
                    Clienti = clienti,
                    Orders = orders,
                };
                return View(ViewModel);
            }
        }
        [Authorize(Roles = "Delivery")]
        [HttpPost]
        public ActionResult Create(Delivery newDelivery)
        {
            _context.Deliveries.Add(new Delivery{ Name = newDelivery.Name, UserId = User.Identity.GetUserId() });
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Delivery")]
        public ActionResult AcceptCommand(int id)
        {
            var userID = User.Identity.GetUserId();
            var delivery = _context.Deliveries.Where(o => o.UserId == userID).FirstOrDefault();
            var order = _context.Orders.Where(o => o.Id == id).FirstOrDefault();
            var client = _context.Clienti.Where(o => o.Id == order.CliendId).FirstOrDefault();
            List<OrderItem> orderItems = new List<OrderItem>();
            orderItems = _context.OrderItem.Where(x => x.CartId == order.CartId).ToList();

            List<Produs> produse = new List<Produs>();

            foreach (var item in orderItems)
            {
                produse.Add(_context.Produse.Where(x => x.Id == item.ProductId).FirstOrDefault());
            }


            var ViewModel = new DeliveryDetailsViewModel
            {
                Client = client,
                Produse = produse,
                Order = order
            };

            var result = _context.Orders.Where(_o => _o.Id == order.Id).FirstOrDefault();

            if (result != null)
            {
                result.DeliveryId = delivery.Id;
                result.Status = EnumStatus.Acceptat;
                result.DeliveryId = delivery.Id;
                _context.SaveChanges();
            }

            return View(ViewModel);

        }
        [Authorize(Roles = "Delivery")]
        public ActionResult Delivered(int id)
        {          
            var result = _context.Orders.Where(_o => _o.Id == id).FirstOrDefault();

            if (result != null)
            {   result.DeliveredAt = DateTime.Now;
                result.Status = EnumStatus.Livrat;
                _context.SaveChanges();
            }

            return RedirectToAction("Index");

        }

        public ActionResult CurrentOrders()
        {
            var userID = User.Identity.GetUserId();
            var delivery = _context.Deliveries.Where(o => o.UserId == userID).FirstOrDefault();
            List<Order> orders = _context.Orders.Where(_o => _o.DeliveryId == delivery.Id && _o.Status == EnumStatus.Acceptat ).ToList();

            var ViewModel = new DeliveryHistoryViewModel
            {
                Orders = orders,
            };

            return View(ViewModel);
        }

        public ActionResult HistoryOrders()
        {
            var userID = User.Identity.GetUserId();
            var delivery = _context.Deliveries.Where(o => o.UserId == userID).FirstOrDefault();
            List<Order> orders = _context.Orders.Where(_o => _o.DeliveryId == delivery.Id && _o.Status == EnumStatus.Livrat).ToList();

            var ViewModel = new DeliveryHistoryViewModel
            {
                Orders = orders,
            };

            return View(ViewModel);
        }
    }
}