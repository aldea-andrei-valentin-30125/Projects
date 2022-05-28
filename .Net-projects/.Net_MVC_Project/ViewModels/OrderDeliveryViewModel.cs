using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCFinalProject.Models;

namespace MVCFinalProject.ViewModels
{
    public class OrderDeliveryViewModel
    {
        public List<Client> Clienti { get; set; }
        public List<Order> Orders { get; set; }
        
    }
}