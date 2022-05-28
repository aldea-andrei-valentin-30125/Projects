using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCFinalProject.Models
{
    public class Produs
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }
}