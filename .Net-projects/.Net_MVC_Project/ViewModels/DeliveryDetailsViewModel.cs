using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCFinalProject.Models;

namespace MVCFinalProject.ViewModels
{
    public class DeliveryDetailsViewModel
    {
        public Order Order { get; set; }
        public Client Client { get; set; }
        public List<Produs> Produse { get; set; }
    }
}