using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCFinalProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (User.IsInRole("Restaurant"))
            {
                return RedirectToAction("Index","Restaurante");
            }
            else
            {
                if (User.IsInRole("Delivery"))
                {
                    return RedirectToAction("Index", "Delivery");
                }
                else
                {
                    if (User.IsInRole("Client"))
                    {
                        return RedirectToAction("Index", "Client");
                    }
                    else { return RedirectToAction("Login", "Account"); }
                }
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}