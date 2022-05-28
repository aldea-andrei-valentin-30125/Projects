using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCFinalProject.Models;

namespace MVCFinalProject.ViewModels
{
    public class CartViewModel
    {
        public Client Clienti { get; set; }
        public List<Produs> Produse { get; set; }

    }
}